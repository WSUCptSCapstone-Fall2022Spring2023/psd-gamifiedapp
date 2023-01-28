using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Allows a text box to be typed one character at a time with a slight delay instead of all at once.
/// </summary>
public class SequentialTyper : MonoBehaviour
{
    /// <summary>
    /// A reference to the text that the sequential typer is tied to.
    /// </summary>
    public TMP_Text TextReference;

    /// <summary>
    /// The delay (in seconds) between characters being printed.
    /// </summary>
    public float TextDelay;

    /// <summary>
    /// The private queue of characters to write sequentially.
    /// </summary>
    private string textQueue = "";

    /// <summary>
    /// The time since last character was printed.
    /// </summary>
    private float textTimer;

    /// <summary>
    /// Stars a new typing job, which will clear text and begin typing given text sequentially.
    /// </summary>
    /// <param name="text"></param>
    public void GiveTypingJob(string text) 
    {
        if (TextDelay == 0) 
        { 
            TextReference.text = text;
            textQueue = string.Empty;
            return;
        }

        TextReference.text = "";
        textQueue = text;
    }

    /// <summary>
    /// Update gets called every frame
    /// </summary>
    public void Update()
    {
        if (textQueue != string.Empty) 
        {
            textTimer += Time.deltaTime;
            if (textTimer > TextDelay) 
            {
                textTimer = 0;
                TextReference.text += textQueue[0];
                textQueue = textQueue[1..];
            }
        }
    }
}
