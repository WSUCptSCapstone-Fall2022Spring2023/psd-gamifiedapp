using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Cutscene action that changes text colors
/// </summary>
public class CutsceneTextColor : MonoBehaviour
{
    /// <summary>
    /// The new color for the text
    /// </summary>
    public Color NewColor;

    /// <summary>
    /// The sequential typer to print to.
    /// </summary>
    public TMP_Text TextAsset;

    /// <summary>
    /// Appends text to sequential typer.
    /// </summary>
    public void Trigger()
    {
        TextAsset.color = NewColor;
    }
}
