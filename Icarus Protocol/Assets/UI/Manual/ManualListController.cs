using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This is the main controller for the entries in the manual.
/// </summary>
public class ManualListController : MonoBehaviour
{
    /// <summary>
    /// Prefab of a manual entry button
    /// </summary>
    public GameObject ButtonPrefab;

    /// <summary>
    /// Reference to description of a manual entry
    /// </summary>
    public ManualDescriptionBehavior ManualDescriptionReference;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Runs initialization on the manual entry list and creates unlocked manual entry buttons
    /// </summary>
    public void Initialize()
    {
        ManualDescription[] manualEntries = GetComponents<ManualDescription>();

        foreach (GameObject child in GetComponentsInChildren<ManualButtonBehavior>().Select(e => e.gameObject))
        {
            if (child != this.gameObject) Destroy(child);
        }
        foreach (ManualDescription description in manualEntries.Where(e => e.Prerequisite == null || e.Prerequisite.LevelProgress.LevelComplete))
        {
            GameObject newButton = Instantiate(ButtonPrefab, this.transform);
            InitializeButton(newButton, description);
        }
    }

    /// <summary>
    /// This initializes the name and corresponding values of the manual entry button.
    /// </summary>
    /// <param name="button">This is the button being modified.</param>
    /// <param name="level">This is the cooresponding level for the button.</param>
    void InitializeButton(GameObject button, ManualDescription description)
    {
        ManualButtonBehavior behavior = button.GetComponent<ManualButtonBehavior>();
        behavior.Initialization(description, ManualDescriptionReference);
    }
}
