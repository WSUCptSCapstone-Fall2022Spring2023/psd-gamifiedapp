using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that sits on the main Level Player, and is the primary endpoint for UI control and initialization.
/// </summary>
public class LevelPlayerController : MonoBehaviour
{
    /// <summary>
    /// Stores the PhaseDefinition for the current phase.
    /// </summary>
    public LevelDefinition PhaseDefinition;

    /// <summary>
    /// Stores the active IronPython container for the current level.
    /// </summary>
    public IronPythonContainer IPContainer;

    /// <summary>
    /// A reference to the simulate button for initialization purposes.
    /// </summary>
    public SimulateButtonScript SimulateButton;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        SimulateButton.PhaseDefinition = PhaseDefinition;
        SimulateButton.IPContainer = IPContainer;
    }
}
