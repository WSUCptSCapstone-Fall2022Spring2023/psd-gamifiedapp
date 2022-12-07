using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the controller for manual entry description
/// </summary>
public class ManualDescription : MonoBehaviour
{
    /// <summary>
    /// The name of the manual entry.
    /// </summary>
    public string manualEntryName;

    /// <summary>
    /// The description of the manual entry.
    /// </summary>
    public TextAsset manualEntryDescription;

    /// <summary>
    /// Stores the level that is needed to unlock this manual entry.
    /// </summary>
    public LevelDescription Prerequisite;
}
