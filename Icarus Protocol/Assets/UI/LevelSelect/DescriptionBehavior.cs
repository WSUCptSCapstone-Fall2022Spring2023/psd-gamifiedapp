using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionBehavior : MonoBehaviour
{
    /// <summary>
    /// This is a reference to the cooresponding level description
    /// </summary>
    public LevelDescription LevelDescription;

    /// <summary>
    /// This is text for the header
    /// </summary>
    public TMP_Text HeaderText;

    /// <summary>
    /// This is text for the body
    /// </summary>
    public TMP_Text BodyText;

    /// <summary>
    /// Callable method for initilization of the button's values.
    /// </summary>
    public void Initialization(LevelDescription level)
    {
        LevelDescription = level;
        HeaderText.text = level.levelName;
        BodyText.text = level.levelDescription;
    }
}
