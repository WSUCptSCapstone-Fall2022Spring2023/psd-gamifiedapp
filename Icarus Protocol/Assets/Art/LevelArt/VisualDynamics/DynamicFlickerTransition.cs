using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicFlickerTransition : MonoBehaviour
{
    /// <summary>
    /// The amount of time to take to perform the transition
    /// </summary>
    public float TransitionTime;

    /// <summary>
    /// The optional alternate image to swap between.
    /// </summary>
    public Image AlternateImage;

    /// <summary>
    /// The image reference to flicker on and off
    /// </summary>
    private Image mImageRef;

    /// <summary>
    /// The timer for tracking short flicker durations.
    /// </summary>
    private float mShortTimer;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mImageRef = GetComponent<Image>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (TransitionTime > 0)
        {
            if (mShortTimer <= 0)
            {
                mImageRef.enabled = !mImageRef.enabled;
                if (AlternateImage != null) AlternateImage.enabled = !mImageRef.enabled;
                mShortTimer = Random.Range(0.01f, 0.2f);
            }
            mShortTimer -= Time.deltaTime;
            TransitionTime -= Time.deltaTime;
        }
        else 
        {
            mImageRef.enabled = false;
            if (AlternateImage != null) AlternateImage.enabled = true;
        }
    }
}
