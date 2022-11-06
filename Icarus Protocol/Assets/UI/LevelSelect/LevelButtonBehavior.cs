using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

/// <summary>
/// This is the behaviors for the level selection button
/// </summary>
public class LevelButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// A reference to the completion icon to the right of the level text.
    /// </summary>
    public UnityEngine.UI.Image Icon;

    /// <summary>
    /// The image to use for an incomplete level
    /// </summary>
    public Sprite IncompleteImage;

    /// <summary>
    /// The image to use for a complete level.
    /// </summary>
    public Sprite CompleteImage;

    /// <summary>
    /// This is a reference to the cooresponding level description
    /// </summary>
    private LevelDescription levelDescription;

    /// <summary>
    /// This a reference to the level description behavior
    /// </summary>
    private DescriptionBehavior description;

    /// <summary>
    /// Callable method for initilization of the button's values.
    /// </summary>
    public void Initialization (LevelDescription level, DescriptionBehavior description)
    {
        this.description = description;
        levelDescription = level;
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = levelDescription.levelName;
        Icon.sprite = level.GetComponent<ProgressRecord>().LevelComplete ? CompleteImage : IncompleteImage;
    }

    /// <summary>
    /// This is the onclick behavior for clicking a level selection button
    /// </summary>
    public void OnClick()
    {
        description.gameObject.SetActive(true);
        description.Initialization(levelDescription);
    }
}
