using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controlls the phase-specific UI, serving as an enpoint for providing the internal UI necessary external resources.
/// </summary>
public class PhaseUIController : MonoBehaviour
{
    /// <summary>
    /// A reference to the public IronPythonContainer
    /// </summary>
    public IronPythonContainer IPContainer;

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
    /// Start runs on the first fram which the object exists.
    /// </summary>
    public void Start()
    {
        IPContainer = GameObject.FindGameObjectWithTag("IronPythonContainer").GetComponent<IronPythonContainer>();
        IPContainer.mCachedLevel.ActionGroups = this.ActionGroups;
        IPContainer.mCachedLevel.ResetGroup = this.ResetGroup;
    }
}
