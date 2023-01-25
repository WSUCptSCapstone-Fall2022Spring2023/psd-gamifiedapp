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

    private TMP_Text text;
    private FontWeight startingWeight;

    /// <summary>
    /// A reference to the UI Handler for facilitating layout transitions.
    /// </summary>
    public UILayoutHandler UiHandler;

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        startingWeight = text.fontWeight;

    }

    /// <summary>
    /// Called when the button is clicked.
    /// </summary>
    public void OnClick()
    {
        UiHandler.TransitionToLevelSelect(0);
    }

    public void OnHover()
    {
        text.color = Color.black;
        text.fontWeight = FontWeight.Bold;
    }

    public void OffHover() 
    {
        text.color = Color.white;
        text.fontWeight = startingWeight;
    }
}
