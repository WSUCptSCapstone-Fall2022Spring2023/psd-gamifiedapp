using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The IronPython Container handles and runs the game's internal IronPython interpreter.
/// It is the primary endpoint for interactions with the IronPython
/// </summary>
public class IronPythonContainer : MonoBehaviour
{
    /// <summary>
    /// Stores a private internal reference to the running engine managing the IronPython interpreter
    /// </summary>
    private ScriptEngine mEngine { get; set; }

    /// <summary>
    /// Stores a private internal reference to the scope object used to provide bindings to IronPython
    /// </summary>
    private ScriptScope mLevelScope { get; set; }

    /// <summary>
    /// Stores a private internal reference to the scope object used to limit the player's influence
    /// </summary>
    private ScriptScope mUserScope { get; set; }

    /// <summary>
    /// Stores a private internal cache of the initialized level.
    /// </summary>
    private LevelDefinition mCachedLevel { get; set; }

    /// <summary>
    /// Is true if user code is being simulated, false otherwise.
    /// </summary>
    private bool mSimulating { get; set; }

    /// <summary>
    /// The timer variable used to time how often user code is simulated.
    /// </summary>
    private float mCodeLoopTimer { get; set; }

    /// <summary>
    /// Stores the private internal cached user code for the simulation.
    /// </summary>
    private string mCachedUserCode { get; set; }

    /// <summary>
    /// Initializes Unity object before the first Update loop.
    /// </summary>
    void Start()
    {
        mEngine = Python.CreateEngine();

        mLevelScope = mEngine.CreateScope();
        mLevelScope.SetVariable("parent", this);
    }

    /// <summary>
    /// Gets called every frame.
    /// </summary>
    public void Update()
    {
        if (mSimulating)
        {
            ScriptSource source = mEngine.CreateScriptSourceFromString("simulate_tick()");
            source.Execute(mLevelScope);

            if (mCodeLoopTimer <= 0)
            {
                mCodeLoopTimer = mCachedLevel.CodeLoopDuration;
                source = mEngine.CreateScriptSourceFromString("simulate()");
                source.Execute(mLevelScope);
            }
            else
            {
                mCodeLoopTimer -= Time.deltaTime;
            }

            //Force scope sync
            foreach (string identifier in mCachedLevel.ExposedMembers)
            {
                mUserScope.SetVariable(identifier, mLevelScope.GetVariable(identifier));
            }
        }
    }

    /// <summary>
    /// Uses a LevelDefinition script to initialize a level's unique simulation code and scope elements.
    /// </summary>
    public void InitializeLevel(LevelDefinition level) 
    {
        mCachedLevel = level;

        //Initialize level scope
        mLevelScope = mEngine.CreateScope();
        mLevelScope.SetVariable("parent", this);
        mLevelScope.SetVariable("environment", level);
        ScriptSource source = mEngine.CreateScriptSourceFromFile(Application.dataPath + level.TestFile);
        source.Execute(mLevelScope);

        //Dynamically initialize player scope
        mUserScope = mEngine.CreateScope();
        foreach (string identifier in level.ExposedMembers) 
        {
            mUserScope.SetVariable(identifier, mLevelScope.GetVariable(identifier));
        }
    }

    /// <summary>
    /// Simulates the cached user code by running the simulate() function in the level python
    /// </summary>
    public void Simulate(string userCode) 
    {
        mCachedUserCode = userCode;

        //Exit early if level has not been initialized.
        if (mCachedLevel == null) return;
        mSimulating = true;
    }

    /// <summary>
    /// Returns the value of an identifier available in the level scope.
    /// </summary>
    /// <param name="valueIdentifier"></param>
    /// <returns></returns>
    public dynamic GetPythonValue(string valueIdentifier) 
    {
        if (mCachedLevel == null) return null;
        return mLevelScope.GetVariable(valueIdentifier);
    }

    /// <summary>
    /// A binding intended to be called only by IronPython, runs the cached user code in the current level scope
    /// </summary>
    public void execute_user_code() 
    {
        ScriptSource source = mEngine.CreateScriptSourceFromString(mCachedUserCode);
        source.Execute(mUserScope);

        //Force scope sync
        foreach (string identifier in mCachedLevel.ExposedMembers)
        {
            mLevelScope.SetVariable(identifier, mUserScope.GetVariable(identifier));
        }
    }

    /// <summary>
    /// A binding intended to be called only by IronPython. Ends the simulation with a particular exit code.
    /// 0 indicates a success
    /// >0 indicates some form of failure.
    /// </summary>
    /// <param name="exitCode"></param>
    public void end_simulation(int exitCode) 
    {
        mSimulating = false;
        InitializeLevel(mCachedLevel);
        //TODO: Remove Debug
        Debug.Log($"Exited with code: {exitCode}");
    }
}
