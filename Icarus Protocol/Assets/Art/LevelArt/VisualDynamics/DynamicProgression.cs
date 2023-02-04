using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows a series of images to be shown in sequence
/// </summary>
public class DynamicProgression : MonoBehaviour
{
    /// <summary>
    /// The array of images to iterate through in the progression
    /// </summary>
    public List<Image> Images;

    /// <summary>
    /// The delay between each image.
    /// </summary>
    public float Delay;

    /// <summary>
    /// If true then the progression will loop on completion;
    /// </summary>
    public bool Looping;

    /// <summary>
    /// The timer for each iteration.
    /// </summary>
    private float timer;

    /// <summary>
    /// The index of the currently shown image in the progression.
    /// </summary>
    private int shownImage = 0;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        timer = Delay;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (timer <= 0) 
        {
            timer = Delay;
            if (shownImage < Images.Count - 1)
            {
                Images[shownImage].enabled = false;
                shownImage++;
                Images[shownImage].enabled = true;
            }
            else 
            {
                this.enabled = false;
                return;
            }
        }
        timer -= Time.deltaTime;
    }
}
