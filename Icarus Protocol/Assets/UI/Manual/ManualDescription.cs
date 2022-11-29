using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the controller for manual entry description
/// </summary>
public class ManualDescription : MonoBehaviour
{
    /// <summary>
    /// The name of the level.
    /// </summary>
    public string manualEntryName;

    /// <summary>
    /// The description of the level.
    /// </summary>
    public string manualEntryDescription;

    /// <summary>
    /// Stores a list of the levels that must be completed before this level is unlocked.
    /// </summary>
    public LevelDescription[] Prerequisites = new LevelDescription[0];
}
