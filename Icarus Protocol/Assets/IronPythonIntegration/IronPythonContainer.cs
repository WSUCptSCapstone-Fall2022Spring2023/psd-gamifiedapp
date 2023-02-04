using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
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
    /// An event that triggers each time that the simulation exist. 
    /// Subscribed to by the UI and phase definitions to manage phase transitions and responses.
    /// </summary>
    public event EventHandler<(int, string)> OnSimulationExit;

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
    public PhaseDefinition mCachedLevel { get; set; }

    /// <summary>
    /// Is true if user code is being simulated, false otherwise.
    /// </summary>
    private bool mSimulating { get; set; }

    /// <summary>
    /// The timer variable used to time how often user code is simulated.
    /// </summary>
    private float mCodeLoopTimer { get; set; }

    /// <summary>
    /// The timer variable used to time the "fast ticks"
    /// </summary>
    private float tickTimer { get; set; }

    /// <summary>
    /// Stores the private internal cached user code for the simulation.
    /// </summary>
    private string mCachedUserCode { get; set; }

    /// <summary>
    /// Runs when a script is loaded. Has priority over normal start functions.
    /// </summary>
    void Awake()
    {
        mEngine = Python.CreateEngine();
    }

    /// <summary>
    /// Gets called every frame.
    /// </summary>
    public void Update()
    {
        if (mSimulating)
        {
            if (tickTimer <= 0)
            {
                tickTimer = mCachedLevel.FastTickSpeed;
                mEngine.Execute("simulate_tick()", mLevelScope);
            }
            else
            {
                tickTimer -= Time.deltaTime;
            }

            if (!mSimulating) return;

            if (mCodeLoopTimer <= 0)
            {
                mCodeLoopTimer = mCachedLevel.CodeLoopDuration;
                mEngine.Execute("simulate()", mLevelScope);
            }
            else
            {
                mCodeLoopTimer -= Time.deltaTime;
            }

            SyncScopes(mLevelScope, mUserScope);
        }
    }

    /// <summary>
    /// Uses a LevelDefinition script to initialize a level's unique simulation code and scope elements.
    /// </summary>
    public void InitializeLevel(PhaseDefinition level) 
    {
        if (mEngine != null)
        {
            mCachedLevel = level;
            mCodeLoopTimer = 0;

            //Initialize level scope
            mLevelScope = mEngine.CreateScope();
            mLevelScope.SetVariable("parent", this);
            mLevelScope.SetVariable("environment", level);
            level.ResetGroup.Invoke();
            ScriptSource source = mEngine.CreateScriptSourceFromString(level.TestFile.text);
            source.Execute(mLevelScope);

            //Dynamically initialize player scope
            mUserScope = mEngine.CreateScope();
            SyncScopes(mLevelScope, mUserScope);
        }
    }

    /// <summary>
    /// Simulates the cached user code by running the simulate() function in the level python
    /// </summary>
    public void Simulate(string userCode) 
    {
        mCachedUserCode = userCode;
        if (mCachedLevel == null) return;
        InitializeLevel(mCachedLevel);
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
        SyncScopes(mUserScope, mLevelScope);
    }

    /// <summary>
    /// A binding intended to be called only by IronPython. Ends the simulation with a particular exit code.
    /// 0 indicates a success
    /// >0 indicates some form of failure.
    /// </summary>
    /// <param name="exitCode"></param>
    /// <param name="optionalMessage">Takes in an optional message accompanying the exit. Used for reporting exception content.</param>
    public void end_simulation(int exitCode, string optionalMessage = "") 
    {
        mSimulating = false;
        OnSimulationExit(this, (exitCode, optionalMessage));

        //TODO: Remove Debug
        Debug.Log(optionalMessage == "" ? $"Simulation exited with code: {exitCode}": $"Simulation exited with message {optionalMessage}");
    }

    /// <summary>
    /// A function intended to be called by IronPython to force a premature synchronization of the level scope to the user scope.
    /// </summary>
    public void push_user_scope() 
    {
        SyncScopes(mLevelScope, mUserScope);
    }

    /// <summary>
    /// A function intended to be called by IronPython to force a premature synchronization of the user scope to the level scope.
    /// </summary>
    public void pull_user_scope()
    {
        SyncScopes(mUserScope, mLevelScope);
    }

    /// <summary>
    /// A function called by IronPython to check if simulation has been halted.
    /// </summary>
    public bool is_simulating() 
    {
        return mSimulating;
    }

    /// <summary>
    /// Transfers the scope data from one scope to another, used to intersect scopes.
    /// </summary>
    /// <param name="fromScope">The scope to take values from</param>
    /// <param name="toScope">The scope to transer values to</param>
    private void SyncScopes(ScriptScope fromScope, ScriptScope toScope) 
    {
        foreach (string identifier in mCachedLevel.ExposedMembers)
        {
            toScope.SetVariable(identifier, fromScope.GetVariable(identifier));
        }
    }
}
