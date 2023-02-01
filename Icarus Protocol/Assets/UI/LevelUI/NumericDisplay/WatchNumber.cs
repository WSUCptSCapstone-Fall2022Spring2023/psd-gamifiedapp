using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchNumber : MonoBehaviour
{
    /// <summary>
    /// The number of decimal places to round the displayed value to.
    /// </summary>
    public int DecimalPlaces;

    /// <summary>
    /// The name of the Python member to target
    /// </summary>
    public string MemberName;

    /// <summary>
    /// The minimum value that the display should be able to show. Does not effect or limit underlying value.
    /// </summary>
    public float MinValue;

    /// <summary>
    /// The maximum value that the display should be able to show. Does not effect or limit underlying value.
    /// </summary>
    public float MaxValue;

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
            mText.text = 0.ToString($"F{DecimalPlaces}");
        }
        else
        {
            mText.text = $"{Mathf.Min(MaxValue, Mathf.Max(MinValue, (Mathf.Round((float)value * Mathf.Pow(10, DecimalPlaces)) / Mathf.Pow(10, DecimalPlaces)))).ToString($"F{DecimalPlaces}")}";
        }
    }
}
