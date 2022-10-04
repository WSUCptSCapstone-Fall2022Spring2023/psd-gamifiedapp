using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulateTestCode : MonoBehaviour
{
    public TMP_InputField mInputField;
    public IronPythonContainer mIPContainer;

    private void Start()
    {
    }

    public void Execute() 
    {
        Debug.Log(mIPContainer.ExecutePython(mInputField.text));
    }
}
