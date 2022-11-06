using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// enum for tracking queued transition
/// </summary>
public enum TransitionType 
{
    LEVEL_SELECT,
    LEVEL_PLAYER,
    NONE
}

/// <summary>
/// Handles transitions between different primary UI layouts.
/// </summary>
public class UILayoutHandler : MonoBehaviour
{
    /// <summary>
    /// A reference to the level select UI
    /// </summary>
    public GameObject LevelSelectUI;

    /// <summary>
    /// A reference to the level player UI
    /// </summary>
    public GameObject LevelPlayerUI;

    /// <summary>
    /// Timer used to delay UI transitions
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// Cached phase definition for delay transitions.
    /// </summary>
    private PhaseDefinition cachedPhase;

    /// <summary>
    /// The queued transition type. NONE if no transition queued.
    /// </summary>
    private TransitionType queuedTransition = TransitionType.NONE;

    /// <summary>
    /// Transitions from the level select to the level player.
    /// </summary>
    public void TransitionToLevelPlayer(PhaseDefinition targetPhase, float delay) 
    {
        cachedPhase = targetPhase;
        timer = delay;
        queuedTransition = TransitionType.LEVEL_PLAYER;
    }

    /// <summary>
    /// Transitions from level player to level select.
    /// </summary>
    public void TransitionToLevelSelect(float delay) 
    {
        timer = delay;
        queuedTransition = TransitionType.LEVEL_SELECT;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    public void Update()
    {
        if (queuedTransition != TransitionType.NONE) 
        {
            if (timer <= 0)
            {
                switch (queuedTransition) 
                {
                    case TransitionType.LEVEL_PLAYER:
                        LevelPlayerTransition(cachedPhase);
                        break;
                    case TransitionType.LEVEL_SELECT:
                        LevelSelectTransition();
                        break;
                }
            }
            timer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Transitions from the level select to the level player.
    /// </summary>
    private void LevelPlayerTransition(PhaseDefinition targetPhase)
    {
        LevelSelectUI.SetActive(false);
        LevelPlayerUI.GetComponent<LevelPlayerController>().InitializePhase(targetPhase);
        LevelPlayerUI.SetActive(true);
        queuedTransition = TransitionType.NONE;
    }

    /// <summary>
    /// Transitions from level player to level select.
    /// </summary>
    private void LevelSelectTransition()
    {
        LevelPlayerUI.SetActive(false);
        LevelSelectUI.SetActive(true);
        queuedTransition = TransitionType.NONE;
    }
}
