using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This will handle text stylings for on and off hover
/// </summary>
public class HoverBehavior : MonoBehaviour
{
    private TMP_Text text;
    private FontWeight startingWeight;

    /// <summary>
    /// Ths Start function that gets the text component and the beginning fontweight style
    /// </summary>
    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        startingWeight = text.fontWeight;

    }

    /// <summary>
    /// On hover the color and font weight changes
    /// </summary>
    public void OnHover()
    {
        text.color = Color.black;
        text.fontWeight = FontWeight.Bold;
    }

    /// <summary>
    /// Off hover the color and font weight changes to the original states
    /// </summary>
    public void OffHover() 
    {
        text.color = Color.white;
        text.fontWeight = startingWeight;
    }
}
