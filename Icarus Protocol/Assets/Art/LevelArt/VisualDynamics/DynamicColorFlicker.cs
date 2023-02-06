using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicColorFlicker : MonoBehaviour
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
    /// The timer for tracking short flicker durations.
    /// </summary>
    private float mShortTimer;

    /// <summary>
    /// The long timer for the overall effect.
    /// </summary>
    private float mLongTimer;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mImageRef = GetComponent<Image>();
        mBaseColor = mImageRef.color;
        mLongTimer = TransitionTime;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (mLongTimer > 0)
        {
            if (mShortTimer <= 0)
            {
                mImageRef.color = mImageRef.color == mBaseColor ? AlternateColor : mBaseColor;
                mShortTimer = Random.Range(0.01f, 0.2f);
            }
            mShortTimer -= Time.deltaTime;
            mLongTimer -= Time.deltaTime;
        }
        else
        {
            mImageRef.color = AlternateColor;
            this.enabled = false;
        }
    }

    /// <summary>
    /// Triggers when the component is reenabled
    /// </summary>
    private void OnEnable()
    {
        mLongTimer = TransitionTime;
    }
}
