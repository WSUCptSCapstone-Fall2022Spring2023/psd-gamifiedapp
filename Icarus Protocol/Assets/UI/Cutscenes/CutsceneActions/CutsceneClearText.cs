using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cutscene action that clears the active text from a text reader.
/// </summary>
public class CutsceneClearText : MonoBehaviour
{
    /// <summary>
    /// The sequential typer to print to.
    /// </summary>
    public SequentialTyper TextAsset;

    /// <summary>
    /// Changes write mode
    /// </summary>
    public void Trigger()
    {
        TextAsset.GiveTypingJob("");
    }
}
