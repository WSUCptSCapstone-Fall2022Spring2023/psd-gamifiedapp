using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberLineHandler : MonoBehaviour
{
    /// <summary>
    /// The identifier of the member to watch for the dynamic value of the meter.
    /// </summary>
    public string ValueIdentifier;

    /// <summary>
    ///  The static maximum value to compare the watched value against when deciding the meter dimensions.
    /// </summary>
    public float MaxValue;

    /// <summary>
    /// The maximum Y scale of the meter.
    /// </summary>
    public float MaxHeight;

    /// <summary>
    /// A reference to the meter transform
    /// </summary>
    public RectTransform BallReference;

    /// <summary>
    /// A reference to the text object that prints out the numeric value of the meter.
    /// </summary>
    public RectTransform NumericLabel;

    /// <summary>
    /// A privately held reference to the phase UI controller for fetching important phase information.
    /// </summary>
    private PhaseUIController phaseController;

    /// <summary>
    /// Stores a reference to the numeric text.
    /// </summary>
    private TMP_Text mTextRef;

    /// <summary>
    /// Stores the starting y position to raise from
    /// </summary>
    private float yPosition;

    /// <summary>
    /// Stores the starting y position of the ball
    /// </summary>
    private float ballYPosition;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        phaseController = GetComponentInParent<PhaseUIController>();
        mTextRef = NumericLabel.GetComponent<TMP_Text>();
        yPosition = NumericLabel.localPosition.y;
        ballYPosition = BallReference.localPosition.y;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float value = (float)(phaseController?.IPContainer.GetPythonValue(ValueIdentifier));
        float height = Mathf.Max(0, Mathf.Min(MaxHeight, MaxHeight * (value / MaxValue)));
        NumericLabel.localPosition = new Vector3(NumericLabel.localPosition.x, yPosition + (height * 100), NumericLabel.localPosition.z);
        BallReference.localPosition = new Vector3(BallReference.localPosition.x, ballYPosition + (height * 100), BallReference.localPosition.z);
        mTextRef.text = $"{(Mathf.Round((float)value * Mathf.Pow(10, 1)) / Mathf.Pow(10, 1)).ToString($"F1")}";
    }
}
