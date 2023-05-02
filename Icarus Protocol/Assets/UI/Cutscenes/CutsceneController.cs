using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controlls the main cutscene UI and provides utilities for playing through cutscene prefabs
/// </summary>
public class CutsceneController : MonoBehaviour
{
    /// <summary>
    /// The Cached cutscene data for the cutscene that's currently being run
    /// </summary>
    public CutsceneData CachedData { get; set; }

    /// <summary>
    /// Stores a reference the UILayoutHandler
    /// </summary>
    public UILayoutHandler UIHandlerRef;

    /// <summary>
    /// Stores a ref to the main text field.
    /// </summary>
    public TMP_Text PrimaryTextField;

    /// <summary>
    /// The timer for the running cutscene.
    /// </summary>
    private float timer {get;set;}

    /// <summary>
    /// The index of the next cutscene trigger to run.
    /// </summary>
    private int currentIndex { get; set; }

    /// <summary>
    /// Run when this object is loaded
    /// </summary>
    public void Start()
    {
        UIHandlerRef = GetComponentInParent<UILayoutHandler>();
    }

    /// <summary>
    /// Resets the visuals for the cutscene UI
    /// </summary>
    public void Initialize() {
        PrimaryTextField.text = "";
        timer = 0;
        currentIndex = 0;
        PrimaryTextField.color = Color.white;
        PrimaryTextField.GetComponent<SequentialTyper>().PrintByLine = false;

        foreach (Image image in GetComponentsInChildren<Image>()) 
        {
           if(image.transform != this.transform) image.color = new Color(0, 0, 0, 0);
        }
    }

    /// <summary>
    /// Plays the cutscene with the specified id.
    /// </summary>
    /// <param name="sceneID">The ID of the cutscene to play</param>
    public void PlayCutscene(string sceneID) {
        CachedData = GetComponentsInChildren<CutsceneData>().FirstOrDefault(e => e.CutsceneID == sceneID);
        if (CachedData == null) return;
        StartCoroutine(RunCutscene());
    }

    private IEnumerator RunCutscene() {
        while (CachedData.CutsceneSteps.Count > currentIndex) 
        {
            timer += Time.deltaTime;
            if (timer > CachedData.CutsceneSteps[currentIndex].StartTime)
            {
                CachedData.CutsceneSteps[currentIndex].Triggers.Invoke();
                currentIndex++;
            }
            yield return null;
        }

        UIHandlerRef.CloseCutsceneUI();
    }
}
