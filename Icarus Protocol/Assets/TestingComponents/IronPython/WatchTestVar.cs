using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchTestVar : MonoBehaviour
{
    public string varIdentifier;

    private PhaseUIController parent;

    private TMP_Text mText;

    private void Start()
    {
        mText = GetComponent<TMP_Text>();
        parent = GetComponentInParent<PhaseUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        dynamic value = parent?.IPContainer.GetPythonValue(varIdentifier);
        if (value != null) 
        {
            mText.text = $"{varIdentifier}: {(value == null ? "N/A" : Mathf.Round((float)value * 100) / 100)}";
        }
    }
}
