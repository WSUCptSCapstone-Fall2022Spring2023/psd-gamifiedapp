using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The behavioral class for quiting to the main menu
/// </summary>
public class QuitToStartMenuButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    /// <summary>
    /// On click behavior for transitioning to the demo
    /// </summary>
    public void OnClick()
    {
        UiHandler.TranistionToStartMenu(0);
    }
}
