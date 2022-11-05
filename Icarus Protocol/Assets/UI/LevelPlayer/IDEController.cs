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
    /// The blanks being used in this phase.
    /// </summary>
    private List<TMP_InputField> blanks = new List<TMP_InputField>();

    /// <summary>
    /// Stores the raw text segments of the example code
    /// </summary>
    private List<string> textSegements = new List<string>();

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
            BuildBlanks(text);
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
        blanks = new List<TMP_InputField>();
        textSegements = new List<string>();

        string[] segments = Regex.Split(rawText, @"\[\[|\]\]");
        StringBuilder backingString = new StringBuilder();
        foreach (string segment in segments) 
        {
            if (int.TryParse(segment, out int parsedValue))
            {
                AddBlank(backingString, parsedValue);
            }
            else
            {
                backingString.Append(segment);
                textSegements.Add(segment);
            }
        }
        StaticText.text = backingString.ToString();
    }


    /// <summary>
    /// Adds and initializes a blank.
    /// </summary>
    /// <param name="backingString">A reference to the iterating background string</param>
    /// <param name="parsedValue">The value marking the intended length of the blank.</param>
    private void AddBlank(StringBuilder backingString, int parsedValue)
    {
        blanks.Add(Instantiate(BlankPrefab, this.transform).GetComponent<TMP_InputField>());
        Vector2 blankPosition = LocateTextPosition(backingString.ToString());
        RectTransform blankTransform = blanks.Last().GetComponent<RectTransform>();
        blankTransform.anchoredPosition = blankPosition;
        blankTransform.sizeDelta = new Vector2(13 * parsedValue + 10, 30);
        backingString.Append(String.Concat(Enumerable.Repeat(" ", parsedValue)));
        blanks.Last().characterLimit = parsedValue;
    }

    /// <summary>
    /// Locates the expected position of a character in a text object
    /// </summary>
    private Vector2 LocateTextPosition(string text) 
    {
        List<string> splitString = text.Split('\n').ToList();
        var yPosition = (splitString.Count() - 1) * -27.5f + 437.5f;
        Debug.Log(splitString.Last());
        var xPosition = (splitString.Last().Length) * 13 - 365;
        Debug.Log($"{xPosition} : {yPosition}");
        return new Vector2(xPosition, yPosition);
    }
}
