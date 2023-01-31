using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the logic for a basic numeric meter
/// </summary>
public class MeterHandler : MonoBehaviour
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
    public RectTransform MeterReference;

    /// <summary>
    /// A privately held reference to the phase UI controller for fetching important phase information.
    /// </summary>
    private PhaseUIController phaseController;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        phaseController = GetComponentInParent<PhaseUIController>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        float value = (float)(phaseController?.IPContainer.GetPythonValue(ValueIdentifier));
        float height = MaxHeight * (value / MaxValue);
        MeterReference.localScale = new Vector3(MeterReference.localScale.x, height, MeterReference.localScale.z);
    }
}
