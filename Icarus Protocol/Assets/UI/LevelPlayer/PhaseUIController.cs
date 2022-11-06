using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls the phase-specific UI, serving as an enpoint for providing the internal UI necessary external resources.
/// </summary>
public class PhaseUIController : MonoBehaviour
{
    /// <summary>
    /// A reference to the public IronPythonContainer
    /// </summary>
    public IronPythonContainer IPContainer;

    /// <summary>
    /// Start runs on the first fram which the object exists.
    /// </summary>
    public void Start()
    {
        IPContainer = GameObject.FindGameObjectWithTag("IronPythonContainer").GetComponent<IronPythonContainer>();
    }
}
