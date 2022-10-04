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

    private ScriptScope mScope { get; set; }

    /// <summary>
    /// Initializes Unity object before the first Update loop.
    /// </summary>
    void Start()
    {
        mEngine = Python.CreateEngine();

        mScope = mEngine.CreateScope();
        mScope.SetVariable("parent", this);

        ICollection<string> searchPaths = mEngine.GetSearchPaths();

        //Path to the Python standard library
        searchPaths.Add(Application.dataPath + @"\Plugins\Lib\");
        mEngine.SetSearchPaths(searchPaths);
    }

    /// <summary>
    /// Executes the provided code as python in the running engine. 
    /// </summary>
    /// <param name="input">The Python string to be executed.</param>
    /// <returns>The evaluation of the Python string.</returns>
    public dynamic ExecutePython(string input) 
    {
        ScriptSource source = mEngine.CreateScriptSourceFromString(input);
        return source.Execute(mScope);
    }

    public void DebugMessage() 
    {
        Debug.Log("It Worked");
    }
}
