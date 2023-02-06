using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProportionalMeterHandler : MonoBehaviour
{
    /// <summary>
    /// The identifier of the member to watch for the dynamic value of the meter.
    /// </summary>
    public string ValueOneIdentifier;

    /// <summary>
    /// The identifier of the member to watch for the dynamic value of the meter.
    /// </summary>
    public string ValueTwoIdentifier;

    /// <summary>
    /// The maximum Y scale of the meter.
    /// </summary>
    public float MaxWidth;

    /// <summary>
    /// The amount of smoothing to apply to the motion of the bar. Higher values are smoother but may cause bar to lag behind data.
    /// </summary>
    public float Speed;

    /// <summary>
    /// A reference to the meter transform
    /// </summary>
    public RectTransform MeterReference;

    /// <summary>
    /// A reference to the text object that prints out the numeric value of the meter.
    /// </summary>
    public RectTransform NumericLabelOne;

    /// <summary>
    /// A reference to the text object that prints out the numeric value of the meter.
    /// </summary>
    public RectTransform NumericLabelTwo;

    /// <summary>
    /// A privately held reference to the phase UI controller for fetching important phase information.
    /// </summary>
    private PhaseUIController phaseController;

    /// <summary>
    /// Stores a reference to the numeric text.
    /// </summary>
    private TMP_Text mTextRefOne;

    /// <summary>
    /// Stores a reference to the numeric text.
    /// </summary>
    private TMP_Text mTextRefTwo;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        phaseController = GetComponentInParent<PhaseUIController>();
        mTextRefOne = NumericLabelOne.GetComponent<TMP_Text>();
        mTextRefTwo = NumericLabelTwo.GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float valueOne = (float)(phaseController?.IPContainer.GetPythonValue(ValueOneIdentifier));
        float valueTwo = (float)(phaseController?.IPContainer.GetPythonValue(ValueTwoIdentifier));
        float targetWidth = Mathf.Max(0, Mathf.Min(MaxWidth, MaxWidth * (valueOne / Mathf.Max(1, valueOne + valueTwo))));
        MeterReference.localScale += new Vector3((targetWidth - MeterReference.localScale.x) * Speed * Time.deltaTime, 0, 0);
        mTextRefOne.text = $"{(Mathf.Round((float)valueOne * Mathf.Pow(10, 1)) / Mathf.Pow(10, 1)).ToString($"F1")}";
        mTextRefTwo.text = $"{(Mathf.Round((float)valueTwo * Mathf.Pow(10, 1)) / Mathf.Pow(10, 1)).ToString($"F1")}";
    }
}
