using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulateTestCode : MonoBehaviour
{
    public TMP_InputField InputField;
    public IronPythonContainer IPContainer;
    public LevelDefinition TestLevel;

    private void Start()
    {
    }

    public void Execute() 
    {
        IPContainer.InitializeLevel(TestLevel);
        IPContainer.CachedUserCode = InputField.text;
        Debug.Log(IPContainer.Simulate());
    }

    public void PrintFirst() 
    {
        Debug.Log("First");
    }

    public void PrintSecond()
    {
        Debug.Log("Second");
    }

    public void PrintThird()
    {
        Debug.Log("Third");
    }
}
