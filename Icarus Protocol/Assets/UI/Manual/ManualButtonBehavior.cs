using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the behavior for manual entry buttons
/// </summary>
public class ManualButtonBehavior : MonoBehaviour
{
    /// <summary>
    /// This is a reference to the cooresponding level description
    /// </summary>
    private ManualDescription manualDescription;

    /// <summary>
    /// This a reference to the level description behavior
    /// </summary>
    private ManualDescriptionBehavior description;

    /// <summary>
    /// Callable method for initilization of the button's values.
    /// </summary>
    public void Initialization(ManualDescription manualEntry, ManualDescriptionBehavior description)
    {
        this.description = description;
        manualDescription = manualEntry;
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = manualDescription.manualEntryName;
    }

    /// <summary>
    /// This is the onclick behavior for clicking a level selection button
    /// </summary>
    public void OnClick()
    {
        description.Initialization(manualDescription);
    }
}
