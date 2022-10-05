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
    private ScriptScope mScope { get; set; }

    /// <summary>
    /// Stores a private internal cache of the initialized level.
    /// </summary>
    private LevelDefinition mCachedLevel { get; set; }

    /// <summary>
    /// Stores the private internal cached user code for the simulation.
    /// </summary>
    public string CachedUserCode { private get; set; }

    /// <summary>
    /// Initializes Unity object before the first Update loop.
    /// </summary>
    void Start()
    {
        mEngine = Python.CreateEngine();

        mScope = mEngine.CreateScope();
        mScope.SetVariable("parent", this);
    }

    /// <summary>
    /// Uses a LevelDefinition script to initialize a level's unique simulation code and scope elements.
    /// </summary>
    public void InitializeLevel(LevelDefinition level) 
    {
        mCachedLevel = level;

        //Have to re-initialize scope to clear old code
        mScope = mEngine.CreateScope();
        mScope.SetVariable("parent", this);
        mScope.SetVariable("environment", level);
        ScriptSource source = mEngine.CreateScriptSourceFromFile(Application.dataPath + level.TestFile);
        source.Execute(mScope);
    }

    /// <summary>
    /// Simulates the cached user code by running the simulate() function in the level python
    /// </summary>
    public dynamic Simulate() 
    {
        //Exit early if level has not been initialized.
        if (mCachedLevel == null) return null;

        ScriptSource source = mEngine.CreateScriptSourceFromString("simulate()");
        return source.Execute(mScope);
    }

    /// <summary>
    /// A binding intended to be called only by IronPython, runs the cached user code in the current level scope
    /// </summary>
    public dynamic execute_user_code() 
    {
        ScriptSource source = mEngine.CreateScriptSourceFromString(CachedUserCode);
        return source.Execute(mScope);
    }
}
