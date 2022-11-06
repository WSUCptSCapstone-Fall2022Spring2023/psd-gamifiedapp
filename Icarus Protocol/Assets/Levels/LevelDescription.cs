using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// The controller for managing levels.
/// </summary>
public class LevelDescription: MonoBehaviour
{
    /// <summary>
    /// The ID of the level, must be unique from the IDs of other levels. 
    /// </summary>
    public string levelID;

    /// <summary>
    /// The name of the level.
    /// </summary>
    public string levelName;

    /// <summary>
    /// The description of the level.
    /// </summary>
    public string levelDescription;

    /// <summary>
    /// Stores a list of the levels that must be completed before this level is unlocked.
    /// </summary>
    public ProgressRecord[] Prerequisites;
}
