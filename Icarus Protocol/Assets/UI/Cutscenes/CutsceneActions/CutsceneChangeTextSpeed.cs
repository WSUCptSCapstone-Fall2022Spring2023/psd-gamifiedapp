using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cutscene action that changes the speed of the text being printed.
/// </summary>
public class CutsceneChangeTextSpeed : MonoBehaviour
{
    /// <summary>
    /// The new printing delay to apply to the sequential typer.
    /// </summary>
    public float NewSpeed;

    /// <summary>
    /// The sequential typer to print to.
    /// </summary>
    public SequentialTyper TextAsset;

    /// <summary>
    /// Appends text to sequential typer.
    /// </summary>
    public void Trigger()
    {
        TextAsset.TextDelay = NewSpeed;
    }
}
