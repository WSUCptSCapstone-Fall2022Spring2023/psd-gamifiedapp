using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main controller class for the pause menu controller
/// </summary>
public class PauseMenuController : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    /// <summary>
    /// A reference to the return to level button
    /// </summary>
    public GameObject ReturnButton;

    /// <summary>
    /// Initialization method for the pause menu
    /// </summary>
    public void Initialize()
    {
        if (UiHandler.CurrentState != TransitionType.LEVEL_PLAYER)
        {
            ReturnButton.SetActive(false);
        }
        else
        {
            ReturnButton.SetActive(true);
        }

    }
}
