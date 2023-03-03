using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicFlash : MonoBehaviour
{
    /// <summary>
    /// The amount of time to take to perform the transition
    /// </summary>
    public float TransitionTime;

    /// <summary>
    /// The optional alternate color to swap between.
    /// </summary>
    public Color AlternateColor;

    /// <summary>
    /// The image reference to change the color of
    /// </summary>
    private Image mImageRef;

    /// <summary>
    /// The starting color of the image.
    /// </summary>
    private Color mBaseColor;

    /// <summary>
    /// Caches the running coroutine to avoid conflicts
    /// </summary>
    private Coroutine cachedCoroutine;

    void Awake()
    {
        mImageRef = GetComponent<Image>();
        mBaseColor = mImageRef.color;
    }

    /// <summary>
    /// Called to trigger the flash coroutine
    /// </summary>
    public void Flash()
    {
        StopAllCoroutines();
        cachedCoroutine = StartCoroutine(FlashRoutine(mImageRef, AlternateColor, mBaseColor, TransitionTime));
    }

    private static IEnumerator FlashRoutine(Image mImageRef, Color AlternateColor, Color mBaseColor, float TransitionTime) 
    {
        float timer = 0;
        while (mImageRef.color != AlternateColor) 
        {         
            timer += Time.deltaTime;
            if (timer > TransitionTime) break;
            mImageRef.color = (mBaseColor * (1 - (timer / TransitionTime))) + (AlternateColor * (timer / TransitionTime));
            yield return null;
        }

        mImageRef.color = AlternateColor;
        yield return null;
        timer = 0;

        while (mImageRef.color != mBaseColor)
        {            
            timer += Time.deltaTime;
            if (timer > TransitionTime) break;
            mImageRef.color = (mBaseColor * (timer / TransitionTime)) + (AlternateColor * (1 - (timer / TransitionTime)));
            yield return null;
        }

        mImageRef.color = mBaseColor;
    }
}
