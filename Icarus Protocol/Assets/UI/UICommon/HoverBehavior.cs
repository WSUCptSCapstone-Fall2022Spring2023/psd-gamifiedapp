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

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        startingWeight = text.fontWeight;

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
