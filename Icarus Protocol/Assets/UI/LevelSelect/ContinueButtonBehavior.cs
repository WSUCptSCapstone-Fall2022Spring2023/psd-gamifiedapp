using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        uiHandler.TransitionToLevelPlayer(descriptionReference.LevelDescription.GetComponent<PhaseDefinition>(), 0);
    }
}
