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
    public PhaseDefinition PhaseDefinition;

    /// <summary>
    /// Stores the active IronPython container for the current level.
    /// </summary>
    public IronPythonContainer IPContainer;

    /// <summary>
    /// A reference to the simulate button for initialization purposes.
    /// </summary>
    public SimulateButtonScript SimulateButton;

    /// <summary>
    /// A reference to the output window controller to be initialized with the phase.
    /// </summary>
    public OutputController OutputController;

    /// <summary>
    /// The gameobject to spawn in on success
    /// </summary>
    public GameObject SuccessMessage;

    /// <summary>
    /// The gameobject to spawn in on failure
    /// </summary>
    public GameObject FailureMessage;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        SimulateButton.PhaseDefinition = PhaseDefinition;
        SimulateButton.IPContainer = IPContainer;
        OutputController.InitializeScript(PhaseDefinition.ScriptFile);
        OutputController.AdvanceScript();

        IPContainer.OnSimulationExit += SimulationExited;
    }

    /// <summary>
    /// Gets called when the IPContainer exits a simulation
    /// </summary>
    private void SimulationExited(object sender, int exitCode) 
    {
        if (exitCode > 0)
        {
            OutputController.PrintFailureResponse(exitCode);
            Instantiate(FailureMessage, transform);
        }
        else 
        {
            OutputController.AdvanceScript();
            Instantiate(SuccessMessage, transform);
        }
    }
}
