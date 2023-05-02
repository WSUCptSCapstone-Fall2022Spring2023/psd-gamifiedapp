using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Stores the data for a single cutscene with its timing information.
/// </summary>
public class CutsceneData : MonoBehaviour
{
    /// <summary>
    /// The ID used to reference this cutscene for playing
    /// </summary>
    public string CutsceneID;

    /// <summary>
    /// Contains the list of cutscene steps to play
    /// </summary>
    public List<CutsceneStep> CutsceneSteps;
}

/// <summary>
/// Stores the data for a single cutscene step.
/// </summary>
[Serializable]
public class CutsceneStep {
    /// <summary>
    /// Stores the start time of this cutscene step
    /// </summary>
    public float StartTime;

    /// <summary>
    /// Stores the actions that should get triggered at the specified time.
    /// </summary>
    public UnityEvent Triggers;
}
