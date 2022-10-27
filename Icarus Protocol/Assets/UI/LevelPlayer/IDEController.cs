using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A script that manages the IDE object, packaging and controller user code input from multiple code sources
/// and providing the packaged code to other elements.
/// </summary>
public class IDEController : MonoBehaviour
{
    /// <summary>
    /// A reference to the raw input field for when raw player input is being used as a code source.
    /// </summary>
    public TMP_InputField RawInputField;

    /// <summary>
    /// Packages and returns the player code string from the current active code source.
    /// </summary>
    /// <returns></returns>
    public string GetPlayerCode() 
    {
        return RawInputField.text;
    }
}
