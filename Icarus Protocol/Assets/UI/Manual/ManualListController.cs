using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManualListController : MonoBehaviour
{
    /// <summary>
    /// Prefab of a level selection button
    /// </summary>
    public GameObject ButtonPrefab;

    /// <summary>
    /// Reference to description of level
    /// </summary>
    public ManualDescriptionBehavior ManualDescriptionReference;


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
        ManualDescription[] manualEntries = GetComponents<ManualDescription>();

        foreach (GameObject child in GetComponentsInChildren<ManualButtonBehavior>().Select(e => e.gameObject))
        {
            if (child != this.gameObject) Destroy(child);
        }
        foreach (ManualDescription description in manualEntries)
        {
            GameObject newButton = Instantiate(ButtonPrefab, this.transform);
            InitializeButton(newButton, description);
        }
    }

    /// <summary>
    /// This initializes the name and corresponding values of the level button.
    /// </summary>
    /// <param name="button">This is the button being modified.</param>
    /// <param name="level">This is the cooresponding level for the button.</param>
    void InitializeButton(GameObject button, ManualDescription description)
    {
        ManualButtonBehavior behavior = button.GetComponent<ManualButtonBehavior>();
        behavior.Initialization(description, ManualDescriptionReference);
    }
}
