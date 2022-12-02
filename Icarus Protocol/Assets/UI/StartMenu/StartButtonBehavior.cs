using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The behavior for starting the game
/// </summary>
public class StartButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler uiHandler;

    /// <summary>
    /// Called when the button is clicked.
    /// </summary>
    public void OnClick()
    {
        uiHandler.TransitionToLevelSelect(0);
    }
}
