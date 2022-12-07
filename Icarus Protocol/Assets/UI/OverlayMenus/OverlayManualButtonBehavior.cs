using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the behavior for the manual overlay button
/// </summary>
public class OverlayManualButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler uiHandler;

    /// <summary>
    /// This is the onclick behavior for clicking a manual entry button
    /// </summary>
    public void OnClick()
    {
        uiHandler.TransitionToManual(0);
    }
}
