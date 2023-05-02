using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cutscene action that changes the write mode of the text writer
/// </summary>
public class CutsceneChangeWriteMode : MonoBehaviour
{
    /// <summary>
    /// The new write mode for the text
    /// </summary>
    public bool WriteMode;

    /// <summary>
    /// The sequential typer to print to.
    /// </summary>
    public SequentialTyper TextAsset;

    /// <summary>
    /// Changes write mode
    /// </summary>
    public void Trigger()
    {
        TextAsset.PrintByLine = WriteMode;
    }
}
