using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the spawning of the checkboxes that demonstrate phase completion.
/// </summary>
public class CheckboxBuilder : MonoBehaviour
{
    /// <summary>
    /// The prefab for the checkbox.
    /// </summary>
    public GameObject CheckBoxPrefab;

    /// <summary>
    /// The sprite to use for a complete checkbox
    /// </summary>
    public Sprite CompleteSprite;

    /// <summary>
    /// The sprite to use for an incomplete checkbox
    /// </summary>
    public Sprite UnfinishedSprite;

    /// <summary>
    /// The current printing position
    /// </summary>
    private Vector2 headPosition = new Vector2();

    /// <summary>
    /// Builds the boxes as children of this root.
    /// </summary>
    /// <param name="progress">The progress record to base checkboxes on.</param>
    public void BuildBoxes(ProgressRecord progress) 
    {
        headPosition =  new Vector2();
        foreach (GameObject child in GetComponentsInChildren<Transform>().Select(e => e.gameObject)) 
        {
            if (child != this.gameObject) Destroy(child);
        }

        foreach (ProgressRecord.PhaseProgress phase in progress.PhaseCompletion) 
        {
            GameObject box = Instantiate(CheckBoxPrefab, this.transform);
            box.GetComponent<RectTransform>().anchoredPosition = headPosition;
            headPosition += new Vector2(60, 0);
            box.GetComponent<Image>().sprite = phase.PhaseComplete ? CompleteSprite : UnfinishedSprite;
        }
    }
}
