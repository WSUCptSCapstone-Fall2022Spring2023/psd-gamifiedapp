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
    /// The delay coefficient to apply to the value to smooth numeric transitions.
    /// </summary>
    public float Delay;

    /// <summary>
    /// Stores a ref to the controller to allow it to get necessary information
    /// </summary>
    private PhaseUIController mParent;

    /// <summary>
    /// Stores a ref to the text that the script targets, should be placed on the same object.
    /// </summary>
    private TMP_Text mText;

    /// <summary>
    /// The value being actively displayed. Only out of sync with the real backing value if numeric output has delay
    /// </summary>
    private float displayValue;

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
            if (Delay == 0)
            {
                displayValue = (float)value;
            }
            else 
            {
                displayValue += ((float)value - displayValue) * (1/Delay);
            }

            mText.text = $"{Mathf.Min(MaxValue, Mathf.Max(MinValue, (Mathf.Round(displayValue * Mathf.Pow(10, DecimalPlaces)) / Mathf.Pow(10, DecimalPlaces)))).ToString($"F{DecimalPlaces}")}";
        }
    }
}
