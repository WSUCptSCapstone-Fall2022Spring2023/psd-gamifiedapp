using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cutscene action for fading an element from one color to another over a set time-span.
/// </summary>
public class CutsceneFadeElement : MonoBehaviour
{
    /// <summary>
    /// The new color for the image
    /// </summary>
    public Color NewColor;

    /// <summary>
    /// The amount of time to take for the fade
    /// </summary>
    public float TimeSpan;

    /// <summary>
    /// The image ref to change the color of.
    /// </summary>
    public Image ImageRef;

    /// <summary>
    /// The timer tracking the current time.
    /// </summary>
    private float timer;

    /// <summary>
    /// This variable caches the starting color for the transition
    /// </summary>
    private Color startingColor;

    /// <summary>
    /// Appends text to sequential typer.
    /// </summary>
    public void Trigger()
    {
        startingColor = ImageRef.color;
        timer = 0;
        StartCoroutine(PerformFade());
    }

    public IEnumerator PerformFade() {
        while (timer < TimeSpan) {
            timer += Time.deltaTime;
            ImageRef.color = (NewColor * (timer / TimeSpan)) + (startingColor * (1 - (timer / TimeSpan)));
            yield return null;
        }

        ImageRef.color = NewColor;
    }
}
