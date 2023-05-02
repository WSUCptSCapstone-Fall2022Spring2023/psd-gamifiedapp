using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

/// <summary>
/// The behavior for starting the game
/// </summary>
public class StartButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    /// <summary>
    /// Called when the button is clicked.
    /// </summary>
    public void OnClick()
    {
        UiHandler.TransitionToLevelSelect(0);
        UiHandler.PlayCutscene("intro-scene");
    }
}
