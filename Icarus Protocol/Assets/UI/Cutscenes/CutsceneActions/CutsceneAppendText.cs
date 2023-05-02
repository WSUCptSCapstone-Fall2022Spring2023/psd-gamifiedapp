using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Appends some predefined text to the cutscene text 
/// </summary>
public class CutsceneAppendText : MonoBehaviour
{
    [Multiline]
    /// <summary>
    /// The text to append
    /// </summary>
    public string Text;

    /// <summary>
    /// The sequential typer to print to.
    /// </summary>
    public SequentialTyper TextAsset;

    /// <summary>
    /// Appends text to sequential typer.
    /// </summary>
    public void Trigger() {
        TextAsset.AppendTypingJob(Text);
    }
}
