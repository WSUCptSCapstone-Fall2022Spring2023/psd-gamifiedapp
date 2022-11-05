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
    /// Stores the segments of the example code
    /// </summary>
    private List<GenericSegment> segments = new List<GenericSegment>();

    /// <summary>
    /// Packages and returns the player code string from the current active code source.
    /// </summary>
    /// <returns></returns>
    public string GetPlayerCode() 
    {
        if (fillInBlankMode)
        {
            StringBuilder outputString = new StringBuilder();
            foreach (GenericSegment segment in segments) 
            {
                outputString.Append(segment.ToString());
            }
            return outputString.ToString();
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
        foreach (GenericSegment segment in segments) 
        {
            if (segment.Blank != null) 
            {
                Destroy(segment.Blank.gameObject);
            }
        }
        segments = new List<GenericSegment>();

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
        segments = new List<GenericSegment>();

        string[] splitSections = Regex.Split(rawText, @"\[\[|\]\]");
        StringBuilder backingString = new StringBuilder();
        foreach (string segment in splitSections) 
        {
            if (int.TryParse(segment, out int parsedValue))
            {
                AddBlank(backingString, parsedValue);
            }
            else
            {
                backingString.Append(segment);
                segments.Add(new GenericSegment(segment));
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
        segments.Add( new GenericSegment(Instantiate(BlankPrefab, this.transform).GetComponent<TMP_InputField>()));
        Vector2 blankPosition = LocateTextPosition(backingString.ToString());
        RectTransform blankTransform = segments.Last().Blank.GetComponent<RectTransform>();
        blankTransform.anchoredPosition = blankPosition;
        blankTransform.sizeDelta = new Vector2(13 * parsedValue + 10, 30);
        backingString.Append(String.Concat(Enumerable.Repeat(" ", parsedValue)));
        segments.Last().Blank.characterLimit = parsedValue;
    }

    /// <summary>
    /// Locates the expected position of a character in a text object
    /// </summary>
    private Vector2 LocateTextPosition(string text) 
    {
        List<string> splitString = text.Split('\n').ToList();
        var yPosition = (splitString.Count() - 1) * -27.5f + 437.5f;
        var xPosition = (splitString.Last().Length) * 13 - 365;
        return new Vector2(xPosition, yPosition);
    }

    /// <summary>
    /// A private internal class that holds a segment that is either a string segement OR a blank.
    /// </summary>
    private class GenericSegment 
    {
        /// <summary>
        /// The text value of the segment if it exists
        /// </summary>
        public string Text;

        /// <summary>
        /// The blank reference of the segment if it exists.
        /// </summary>
        public TMP_InputField Blank;

        /// <summary>
        /// True if segement is a blank.
        /// </summary>
        private bool isBlank;

        public GenericSegment(string text) 
        {
            Text = text;
            isBlank = false;
        }

        public GenericSegment(TMP_InputField blank)
        {
            Blank = blank;
            isBlank = true;
        }

        public override string ToString()
        {
            return isBlank ? Blank.text : Text;
        }
    }
}
