using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The LevelDefinition stores all of the essential information representing a single level.
/// </summary>
public class PhaseDefinition : MonoBehaviour
{
    /// <summary>
    /// The ID of this phase, must be unique from the IDs of other phases in this level.
    /// </summary>
    public string ID;

    /// <summary>
    /// Stores an optional reference to the custom UI layout that should be created for this phase.
    /// </summary>
    public GameObject PhaseUI;

    /// <summary>
    /// The filepath of the level test.py file relative to the application data root.
    /// </summary>
    public TextAsset TestFile;

    /// <summary>
    /// The text asset associated with the script for this phase.
    /// </summary>
    public TextAsset ScriptFile;

    /// <summary>
    /// The action groups tied to this level to be activated by the simulation.
    /// Each event represents a group of actions to be called when action group is triggered
    /// </summary>
    public List<UnityEvent> ActionGroups;

    /// <summary>
    /// Functions exactly like an action group, but stores the actions required to reset this phase's effects to a ground state.
    /// </summary>
    public UnityEvent ResetGroup;

    /// <summary>
    /// The delay between each time that the user's code is simulated.
    /// </summary>
    public float CodeLoopDuration;
    
    /// <summary>
    /// Defines the speed of the "fast tick" behavior. 0 means it will run every frame.
    /// </summary>
    public float FastTickSpeed;

    /// <summary>
    /// This list contains the string identifiers of all member variables made available to the player from the lesson file.
    /// </summary>
    public List<string> ExposedMembers;

    /// <summary>
    /// A list containing the friendly names of each of the variables exposed to the player for this phase.
    /// </summary>
    public List<string> FriendlyVariableNames;

    /// <summary>
    /// Holds the reference to the next phase definition in the level in a linked-list style format.
    /// </summary>
    public PhaseDefinition NextPhase;

    /// <summary>
    /// Set to true if this phase is supposed to load in "fill in the blank" mode
    /// </summary>
    public bool FillInBlank;

    /// <summary>
    /// Text Asset containing starter code and or FITB syntax.
    /// </summary>
    public TextAsset starterCode;

    /// <summary>
    /// The id of the cutscene to play the first time this phase is completed
    /// </summary>
    public string PlayCutsceneOnFirstCompletion;

    /// <summary>
    /// A binding intended for use by IronPython. Calls all the actions subscribed to a particular action group.
    /// </summary>
    /// <param name="groupID"></param>
    public void trigger_action_group(int groupID) 
    {
        if (ActionGroups.Count > groupID) 
        {
            ActionGroups[groupID].Invoke();
        }
    }
}