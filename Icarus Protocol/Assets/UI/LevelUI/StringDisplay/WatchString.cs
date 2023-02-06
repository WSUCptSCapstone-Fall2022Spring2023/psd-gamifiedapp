using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchString : MonoBehaviour
{
    /// <summary>
    /// Stores the max length of string to display in the value box.
    /// </summary>
    public int MaxCharacters;

    /// <summary>
    /// The name of the Python member to target
    /// </summary>
    public string MemberName;

    /// <summary>
    /// Stores a ref to the controller to allow it to get necessary information
    /// </summary>
    private PhaseUIController mParent;

    /// <summary>
    /// Stores a ref to the text that the script targets, should be placed on the same object.
    /// </summary>
    private TMP_Text mText;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mText = GetComponent<TMP_Text>();
        mParent = GetComponentInParent<PhaseUIController>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        dynamic value = mParent?.IPContainer.GetPythonValue(MemberName);
        if (value == null) 
        {
            mText.text = "";
        }
        else
        {
            mText.text = $"{value}";
        }
    }
}
