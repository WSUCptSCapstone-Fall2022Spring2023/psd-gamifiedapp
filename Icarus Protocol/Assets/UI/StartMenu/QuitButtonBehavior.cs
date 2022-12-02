using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavior for quiting from the starting menu
/// </summary>
public class QuitButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// The behavior for clicking on the quit button
    /// </summary>
    public void OnClick()
    {
        Application.Quit();
    }
}
