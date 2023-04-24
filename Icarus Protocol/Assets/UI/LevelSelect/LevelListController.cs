using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a Controller for the Level List and Selection UI panel
/// </summary>
public class LevelListController : MonoBehaviour
{
    /// <summary>
    /// Prefab of a level selection button
    /// </summary>
    public GameObject ButtonPrefab;

    /// <summary>
    /// Reference to description of level
    /// </summary>
    public DescriptionBehavior DescriptionReference;


    /// <summary>
    /// Stores the levels in the scene on load.
    /// </summary>
    private GameObject[] levels;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
        Initialize();
    }

    /// <summary>
    /// Runs initialization on the level list and hides the description box.
    /// </summary>
    public void Initialize()
    {
        levels = GameObject.FindGameObjectsWithTag("Level");
        DescriptionReference.gameObject.SetActive(false);
        foreach (GameObject child in GetComponentsInChildren<LevelButtonBehavior>().Select(e => e.gameObject)) 
        {
            if (child != this.gameObject) Destroy(child);
        }
        foreach (GameObject level in levels.Where(e => !e.GetComponent<LevelDescription>().Prerequisites.Any(i => !i.LevelProgress.LevelComplete)).OrderBy(e => e.GetComponent<LevelDescription>().LevelIndex))
        {
            GameObject newButton = Instantiate(ButtonPrefab, this.transform);
            InitializeButton(newButton, level);
        }
    }

    /// <summary>
    /// This initializes the name and corresponding values of the level button.
    /// </summary>
    /// <param name="button">This is the button being modified.</param>
    /// <param name="level">This is the cooresponding level for the button.</param>
    void InitializeButton (GameObject button, GameObject level)
    {
        LevelButtonBehavior behavior = button.GetComponent<LevelButtonBehavior>();
        behavior.Initialization(level.GetComponent<LevelDescription>(), DescriptionReference);
    }
}
