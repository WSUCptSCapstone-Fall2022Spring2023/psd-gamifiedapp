using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The LevelDefinition stores all of the essential information representing a single level.
/// </summary>
public class LevelDefinition : MonoBehaviour
{
    /// <summary>
    /// The filepath of the level test.py file relative to the application data root.
    /// </summary>
    public string TestFile;

    /// <summary>
    /// The action groups tied to this level to be activated by the simulation.
    /// Each event represents a group of actions to be called when action group is triggered
    /// </summary>
    public List<UnityEvent> ActionGroups;

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