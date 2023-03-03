using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes an element to rotate back and forth randomly to create a rotational "jiggle" effect
/// </summary>
public class DynamicAngularJiggle : MonoBehaviour
{
    /// <summary>
    /// The number of full cycles to complete each second.
    /// </summary>
    public float RotationSpeed;

    /// <summary>
    /// The minimum time to delay between direction shifts.
    /// </summary>
    public float MinTime;

    /// <summary>
    /// The maximum time to delay between direction shifts.
    /// </summary>
    public float MaxTime;

    /// <summary>
    /// This timer reflects the amount of time since the last direction shift
    /// </summary>
    private float timer;

    /// <summary>
    /// Equals 1 or -1 depending on direction of rotation. 
    /// </summary>
    private int direction = 1;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        if (Random.Range(MinTime, MaxTime) < timer) 
        {
            direction = -direction;
            timer = 0;
        }

        transform.Rotate(this.transform.forward, RotationSpeed * direction * Time.deltaTime * 360);
    }
}
