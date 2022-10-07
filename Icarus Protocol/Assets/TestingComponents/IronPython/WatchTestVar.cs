using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchTestVar : MonoBehaviour
{
    public IronPythonContainer PythonContainer;

    private TMP_Text mText;

    private void Start()
    {
        mText = GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        dynamic value = PythonContainer.GetPythonValue("testVar");
        mText.text = $"testVar: {(value == null ? "N/A" : Mathf.Round((float)value * 100) / 100)}";
    }
}
