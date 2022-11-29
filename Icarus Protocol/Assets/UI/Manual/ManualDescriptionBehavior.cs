using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the behavior for the description of the Manual UI component
/// </summary>
public class ManualDescriptionBehavior : MonoBehaviour
{
    /// <summary>
    /// This is a reference to the cooresponding manual entry description
    /// </summary>
    public ManualDescription ManualEntryDescription;

    /// <summary>
    /// This is text for the header
    /// </summary>
    public TMP_Text HeaderText;

    /// <summary>
    /// This is text for the body
    /// </summary>
    public SequentialTyper BodyText;

    /// <summary>
    /// Callable method for initilization of the button's values.
    /// </summary>
    public void Initialization(ManualDescription manualEntry)
    {
        ManualEntryDescription = manualEntry;
        HeaderText.text = manualEntry.manualEntryName;
        BodyText.GiveTypingJob(manualEntry.manualEntryDescription.text);
    }
}
