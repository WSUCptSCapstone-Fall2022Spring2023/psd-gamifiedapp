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
    /// Stores a reference to the sound to play when each letter is printed. No sound is played if null.
    /// </summary>
    public AudioSource TextSound;

    /// <summary>
    /// Because playing text audio every letter is too intense, this interval indicates how many letters to print in between each playing of the sound.
    /// </summary>
    public int TextSoundInterval = 1;

    /// <summary>
    /// If this is set to true, the printer will print line by line instead of by character
    /// </summary>
    public bool PrintByLine = false;

    /// <summary>
    /// The private queue of characters to write sequentially.
    /// </summary>
    private string textQueue = "";

    /// <summary>
    /// The time since last character was printed.
    /// </summary>
    private float textTimer;

    /// <summary>
    /// The number of characters printed in this job;
    /// </summary>
    private int currentTextIndex;

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

        textTimer = TextDelay;
        TextReference.text = "";
        textQueue = text;
        currentTextIndex = 0;
    }

    /// <summary>
    /// Stars a new typing job, which will clear text and begin typing given text sequentially.
    /// </summary>
    /// <param name="text"></param>
    public void AppendTypingJob(string text)
    {
        if (TextDelay == 0)
        {
            TextReference.text += text;
            textQueue = string.Empty;
            return;
        }

        textTimer = TextDelay;
        textQueue += text;
        currentTextIndex = 0;
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
                if (!PrintByLine)
                {
                    currentTextIndex++;
                    if (TextSound != null && currentTextIndex % TextSoundInterval == 0 && !char.IsWhiteSpace(textQueue[0])) TextSound.Play();
                    textTimer = char.IsWhiteSpace(textQueue[0]) ? -TextDelay : 0;
                    TextReference.text += textQueue[0];
                    textQueue = textQueue[1..];
                }
                else {
                    if (TextSound != null) TextSound.Play();
                    textTimer = 0;

                    while (textQueue.Length > 0 && textQueue[0] != '\n') {
                        TextReference.text += textQueue[0];
                        textQueue = textQueue[1..];
                    }

                    if (textQueue.Length > 0) {
                        TextReference.text += textQueue[0];
                        textQueue = textQueue[1..];
                    }
                }
            }
        }
    }
}
