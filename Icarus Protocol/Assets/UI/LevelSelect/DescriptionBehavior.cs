using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the behavior for the level description UI component
/// </summary>
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
    public SequentialTyper BodyText;

    /// <summary>
    /// Stores a reference to the text on the continue button
    /// </summary>
    public TMP_Text ButtonText;

    /// <summary>
    /// Reference to the object that builds and rebuils checkboxes marking completion.
    /// </summary>
    public CheckboxBuilder CheckBoxHandler;

    /// <summary>
    /// Callable method for initilization of the button's values.
    /// </summary>
    public void Initialization(LevelDescription level)
    {
        LevelDescription = level;
        HeaderText.text = level.levelName;
        BodyText.GiveTypingJob(level.levelDescription);
        ProgressRecord progressRecord = level.LevelProgress;
        CheckBoxHandler.BuildBoxes(progressRecord);
        ButtonText.text = !progressRecord.PhaseCompletion.Any(e => e.PhaseComplete) ? "Start" : (progressRecord.PhaseCompletion.Any(e => !e.PhaseComplete) ? "Continue" : "Replay");
    }
}
