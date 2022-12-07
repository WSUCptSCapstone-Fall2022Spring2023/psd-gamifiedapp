using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// enum for tracking queued transition
/// </summary>
public enum TransitionType 
{
    NONE,
    LEVEL_SELECT,
    LEVEL_PLAYER,
    START_MENU,
    PAUSE_MENU,
    MANUAL,
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
    /// A reference to the start menu UI
    /// </summary>
    public GameObject StartMenuUI;

    /// <summary>
    /// A reference to the pause menu UI
    /// </summary>
    public GameObject PauseMenuUI;

    ///<summary>
    /// A reference to the manual UI
    /// </summary>
    public GameObject ManualUI;

    /// <summary>
    /// A reference to the manual button to show and hide it in certain states.
    /// </summary>
    public GameObject ManualButton;

    /// <summary>
    /// The current state that the UI is in.
    /// </summary>
    public TransitionType CurrentState;

    /// <summary>
    /// Stores the Over and Under layouts
    /// </summary>
    public TransitionType CurrentOverlay;
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
    /// Transitions to start menu
    /// </summary>
    public void TransitionToStartMenu(float delay)
    {
        timer = delay;
        queuedTransition = TransitionType.START_MENU;
    }
    
    /// <summary>
    /// Transitions to the pause menu
    /// </summary>
    public void TogglePauseMenu(float delay)
    {
        timer = delay;
        queuedTransition = TransitionType.PAUSE_MENU;
    }

    /// <summary>
    /// Closes pause menu
    /// </summary>
    public void ClosePauseMenu()
    {
        UnpauseMenuTransitions();
	}
	
    /// Transitions to manual
    /// </summary>
    /// <param name="delay"></param>
    public void TransitionToManual(float delay)
    {
        timer = delay;
        queuedTransition = TransitionType.MANUAL;
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
                    case TransitionType.START_MENU:
                        StartMenuTransition();
                        break;
                    case TransitionType.PAUSE_MENU:
                        if (CurrentOverlay == TransitionType.PAUSE_MENU)
                        {
                            UnpauseMenuTransitions();
                        }
                        else 
                        {
                            PauseMenuTransition();
                        }  
						break;
                    case TransitionType.MANUAL:
                        ManualTransition();
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
        DisableAllLayouts();
        LevelPlayerUI.GetComponent<LevelPlayerController>().InitializePhase(targetPhase);
        LevelPlayerUI.SetActive(true);
        ManualButton.SetActive(true);
        queuedTransition = TransitionType.NONE;
        CurrentState = TransitionType.LEVEL_PLAYER;
    }

    /// <summary>
    /// Transitions from level player to level select.
    /// </summary>
    private void LevelSelectTransition()
    {

        DisableAllLayouts();

        LevelSelectUI.GetComponentInChildren<LevelListController>().Initialize();
        LevelSelectUI.SetActive(true);
        ManualButton.SetActive(true);
        queuedTransition = TransitionType.NONE;
        CurrentState = TransitionType.LEVEL_SELECT;
    }

    /// <summary>
    /// Transitions to start menu page from pause menu
    /// </summary>
    private void StartMenuTransition()
    {
        DisableAllLayouts();

        StartMenuUI.SetActive(true);
        ManualButton.SetActive(false);
        queuedTransition = TransitionType.NONE;
        CurrentState = TransitionType.START_MENU;
    }

    /// <summary>
    /// Transitions to the pause menu
    /// </summary>
    private void PauseMenuTransition()
    {
        PauseMenuUI.GetComponentInChildren<PauseMenuController>().Initialize();
        PauseMenuUI.SetActive(true);
        queuedTransition = TransitionType.NONE;
        CurrentOverlay = TransitionType.PAUSE_MENU;
    }

    /// <summary>
    /// Transitions from the pause menu
    /// </summary>
    private void UnpauseMenuTransitions()
    {
        PauseMenuUI.SetActive(false);
        CurrentOverlay = TransitionType.NONE;
        queuedTransition = TransitionType.NONE;
    }

    /// <summary>
    /// Disables all layouts
    /// </summary>
    private void DisableAllLayouts()
    {
        StartMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        LevelPlayerUI.SetActive(false);
        LevelSelectUI.SetActive(false);
        ManualButton.SetActive(false);
    }

    /// Transitions to manual.
    /// </summary>
    private void ManualTransition()
    {
        ManualUI.GetComponentInChildren<ManualListController>().Initialize();
        if (CurrentOverlay == TransitionType.NONE)
        {
            ManualUI.SetActive(true);
            CurrentOverlay = TransitionType.MANUAL;
        }
        else 
        {
            ManualUI.SetActive(false);
            CurrentOverlay = TransitionType.NONE;
        }
        queuedTransition = TransitionType.NONE;
    }
}
