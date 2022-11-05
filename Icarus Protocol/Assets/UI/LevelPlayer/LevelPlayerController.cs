using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    /// The sequential typer attached to the variables pane.
    /// </summary>
    public SequentialTyper VariablesPane;

    /// <summary>
    /// The gameobject to spawn in on success
    /// </summary>
    public GameObject SuccessMessage;

    /// <summary>
    /// The gameobject to spawn in on failure
    /// </summary>
    public GameObject FailureMessage;

    /// <summary>
    /// A reference to the IDEController for initialization.
    /// </summary>
    public IDEController IDE;

    /// <summary>
    /// Caches a reference to the currently extant phase UI
    /// </summary>
    private GameObject phaseUI;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        SimulateButton.IPContainer = IPContainer;


        IPContainer.OnSimulationExit += SimulationExited;
        InitializePhase(PhaseDefinition);
    }
    public void InitializePhase(PhaseDefinition phase) 
    {
        //Destroy old phase UI
        if (phaseUI != null) 
        {
            Destroy(phaseUI);
        }

        //Initialize UI elements and new Python context
        PhaseDefinition = phase;
        SimulateButton.PhaseDefinition = phase;
        OutputController.InitializeScript(phase.ScriptFile);
        OutputController.AdvanceScript();
        IPContainer.InitializeLevel(phase);
        PrintVariables();

        //Initialize Editor
        var text = phase.starterCode != null ? phase.starterCode.text : "";
        IDE.InitializeStarterCode(text, phase.FillInBlank);

        //Create new phase UI
        if (PhaseDefinition.PhaseUI != null) 
        {
            phaseUI = Instantiate(PhaseDefinition.PhaseUI, this.transform);
        }
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
            if (PhaseDefinition.NextPhase != null)
            {
                InitializePhase(PhaseDefinition.NextPhase);
            }
            Instantiate(SuccessMessage, transform);
        }
    }

    /// <summary>
    /// Prints the friendly names of this level's variables.
    /// </summary>
    private void PrintVariables() 
    {
        StringBuilder variablesText = new StringBuilder();
        variablesText.AppendLine("Variables:");
        foreach (string identifier in PhaseDefinition.FriendlyVariableNames) 
        {
            variablesText.AppendLine($"  {identifier}");
        }
        VariablesPane.GiveTypingJob(variablesText.ToString());
    }
}
