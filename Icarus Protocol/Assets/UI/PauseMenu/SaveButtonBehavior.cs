using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the behavior for saving your progress from the pause menu
/// </summary>
public class SaveButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// Reference to the save and load handler class
    /// </summary>
    public SaveAndLoad SaveAndLoader;

    /// <summary>
    /// On click behavior for saving from the pause menu
    /// </summary>
    public void OnClick()
    {
        SaveAndLoader.Save();
    }
}
