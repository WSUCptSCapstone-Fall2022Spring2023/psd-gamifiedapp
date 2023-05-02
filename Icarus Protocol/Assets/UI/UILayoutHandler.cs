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
    /// Stores a reference to the logger for playtest logging.
    /// </summary>
    public PlaytestLogger LoggerRef;
    
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
    /// A reference to the CutsceneUI
    /// </summary>
    public GameObject CutsceneUI;

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
    /// The audio to play during UI transitions;
    /// </summary>
    public AudioSource TransitionAudio;

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

    public AudioHandlerBehavior AudioHandlerBehavior;

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
    /// Opens the cutscene UI and plays a particular cutsene id.
    /// </summary>
    /// <param name="sceneID">The scene ID to play when opening the cutscene UI</param>
    public void PlayCutscene(string sceneID, float delay = 0) {
        StartCoroutine(CutsceneDelay(sceneID, delay));
    }

    /// <summary>
    /// Runs a coroutine to delay the triggering of the cutscene
    /// </summary>
    /// <returns></returns>
    private IEnumerator CutsceneDelay(string sceneID, float delay = 0) {
        float timer = 0;
        while (timer < delay) {
            timer += Time.deltaTime;
            yield return null;
        }
        CutsceneUI.GetComponent<CutsceneController>().Initialize();
        CutsceneUI.SetActive(true);
        CutsceneUI.GetComponent<CutsceneController>().PlayCutscene(sceneID);
    }

    /// <summary>
    /// Closes the cutscene UI, if it is open
    /// </summary>
    public void CloseCutsceneUI() {
        CutsceneUI.SetActive(false);
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
                TransitionAudio.Play();
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
        AudioHandlerBehavior.SwitchMusic(targetPhase.GetComponent<LevelDescription>().Music);
        LoggerRef.CreateLog(LogTypes.LEVEL_START, targetPhase.name);
    }

    /// <summary>
    /// Transitions from level player to level select.
    /// </summary>
    private void LevelSelectTransition()
    {
        if (CurrentState == TransitionType.LEVEL_PLAYER) 
        {
            LoggerRef.CreateLog(LogTypes.LEVEL_EXIT, "");
        }

        DisableAllLayouts();

        LevelSelectUI.GetComponentInChildren<LevelListController>().Initialize();
        LevelSelectUI.SetActive(true);
        ManualButton.SetActive(true);
        queuedTransition = TransitionType.NONE;
        CurrentState = TransitionType.LEVEL_SELECT;

        AudioHandlerBehavior.SwitchMusic(AudioHandlerBehavior.MusicType.Lofi);
    }

    /// <summary>
    /// Transitions to start menu page from pause menu
    /// </summary>
    private void StartMenuTransition()
    {
        if (CurrentState == TransitionType.LEVEL_PLAYER)
        {
            LoggerRef.CreateLog(LogTypes.LEVEL_EXIT, "");
        }

        DisableAllLayouts();

        StartMenuUI.SetActive(true);
        ManualButton.SetActive(false);
        queuedTransition = TransitionType.NONE;
        CurrentState = TransitionType.START_MENU;

        AudioHandlerBehavior.SwitchMusic(AudioHandlerBehavior.MusicType.Epic);
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

    /// <summary>
    /// Transitions to manual.
    /// </summary>
    private void ManualTransition()
    {
        ManualUI.GetComponentInChildren<ManualListController>().Initialize();
        if (CurrentOverlay == TransitionType.NONE)
        {
            ManualUI.SetActive(true);
            CurrentOverlay = TransitionType.MANUAL;
            LoggerRef.CreateLog(LogTypes.MANUAL_ACCESS, "");
        }
        else 
        {
            ManualUI.SetActive(false);
            CurrentOverlay = TransitionType.NONE;
            LoggerRef.CreateLog(LogTypes.MANUAL_EXIT, "");
        }
        queuedTransition = TransitionType.NONE;
    }
}
