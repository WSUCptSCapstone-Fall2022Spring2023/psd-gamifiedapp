using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior for returning to the level select page from a level page
/// </summary>
public class ReturnButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    /// <summary>
    /// On click behavior that transitions to level selection from a level
    /// </summary>
    public void OnClick()
    {
        UiHandler.ClosePauseMenu();
        UiHandler.TransitionToLevelSelect(0);
    }

}
