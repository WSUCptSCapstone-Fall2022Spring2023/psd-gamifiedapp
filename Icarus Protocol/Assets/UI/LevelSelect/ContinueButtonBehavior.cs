using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This is the behavior for the continue button for a level.
/// </summary>
public class ContinueButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler uiHandler;

    /// <summary>
    /// A reference to the description box.
    /// </summary>
    public DescriptionBehavior descriptionReference;

    /// <summary>
    /// Called when the button is clicked.
    /// </summary>
    public void On_Click() 
    {
        ProgressRecord progressRecord = descriptionReference.LevelDescription.LevelProgress;
        PhaseDefinition[] phaseDefinitions = descriptionReference.LevelDescription.GetComponents<PhaseDefinition>();
        PhaseDefinition firstIncomplete = phaseDefinitions.FirstOrDefault(e => progressRecord.PhaseCompletion.First(i => i.PhaseID == e.ID).PhaseComplete == false);
        if (firstIncomplete == null)
        {
            firstIncomplete = phaseDefinitions[0];
        }
        uiHandler.TransitionToLevelPlayer(firstIncomplete, 0);
    }
}
