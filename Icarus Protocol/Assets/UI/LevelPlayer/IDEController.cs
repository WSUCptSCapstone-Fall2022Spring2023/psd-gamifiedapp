using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// A reference to the text object used to populated non-interactive static text.
    /// </summary>
    public TMP_Text StaticText;

    /// <summary>
    /// The prefab for a single blank.
    /// </summary>
    public GameObject BlankPrefab;

    /// <summary>
    /// True if fill in the blank mode is on.
    /// </summary>
    private bool fillInBlankMode;

    /// <summary>
    /// Packages and returns the player code string from the current active code source.
    /// </summary>
    /// <returns></returns>
    public string GetPlayerCode() 
    {
        if (fillInBlankMode)
        {
            return StaticText.text;
        }
        else 
        {
            return RawInputField.text;
        }      
    }

    /// <summary>
    /// Sets the starting value of the editor window, and sets the mode of the editor accordingly.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="fillInBlank"></param>
    public void InitializeStarterCode(string text, bool fillInBlank)
    {
        fillInBlankMode = fillInBlank;
        StaticText.text = "";
        RawInputField.text = "";
        if (fillInBlank)
        {
            StaticText.text = text;
            RawInputField.enabled = false;
        }
        else 
        {
            RawInputField.enabled = true;
            RawInputField.text = text;
        }
    }

    /// <summary>
    /// Builds a fill in the blank construct out of the given text
    /// </summary>
    private void BuildBlanks(string rawText) 
    {
        string[] segments = Regex.Split(rawText, @"(\[\[|\]\])");
        StringBuilder backingString = new StringBuilder();
        foreach (string segment in segments) 
        {
            if (Regex.IsMatch(segment, @"[0-9]*"))
            {
                backingString.Append(String.Concat(Enumerable.Repeat(" ", int.Parse(segment))));

            }
            else
            { 
                
            }
        }
    }
}
