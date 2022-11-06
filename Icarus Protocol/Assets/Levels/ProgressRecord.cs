using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A dataobject used to store progress for save and load serialization.
/// </summary>
[Serializable]
public class ProgressRecord : MonoBehaviour
{
    /// <summary>
    /// True if the level as a whole has been completed
    /// </summary>
    public bool LevelComplete;

    /// <summary>
    /// Stores the completion state of each phase in the level associated with that phase's ID
    /// </summary>
    public List<PhaseProgress> PhaseCompletion;

    /// <summary>
    /// An object to help Unity serialize the data.
    /// </summary>
    [Serializable]
    public class PhaseProgress 
    {
        /// <summary>
        /// The ID of the phase
        /// </summary>
        public string PhaseID { get; set; }

        /// <summary>
        /// True if the phase is complete
        /// </summary>
        public bool PhaseComplete { get; set; }
    }
}
