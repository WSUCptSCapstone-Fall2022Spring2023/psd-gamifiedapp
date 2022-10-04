using IronPython.Hosting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateTestCode : MonoBehaviour
{
    public void Execute() 
    {
        var engine = Python.CreateEngine();

        ICollection<string> searchPaths = engine.GetSearchPaths();

        //Path to the folder of greeter.py
        searchPaths.Add(Application.dataPath);
        //Path to the Python standard library
        searchPaths.Add(Application.dataPath + @"\Plugins\Lib\");
        engine.SetSearchPaths(searchPaths);

        dynamic py = engine.ExecuteFile(Application.dataPath + @"\TestingComponents\IronPython\greeter.py");
        dynamic greeter = py.Greeter("Anna");
        Debug.Log(greeter.greet());
        Debug.Log(greeter.random_number(1, 5));
    }
}
