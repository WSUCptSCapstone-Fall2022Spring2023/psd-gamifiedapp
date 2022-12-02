using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The behavior for loading a save file from the starting menu
/// </summary>
public class LoadButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// Reference to the save and load handler class
    /// </summary>
    public SaveAndLoad SaveAndLoader;

    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    /// <summary>
    /// Once clicked the previously saved game will be loaded.
    /// </summary>
    public void OnClick()
    {
        SaveAndLoader.LoadProgress();
        UiHandler.TransitionToLevelSelect(0);
    }
}
