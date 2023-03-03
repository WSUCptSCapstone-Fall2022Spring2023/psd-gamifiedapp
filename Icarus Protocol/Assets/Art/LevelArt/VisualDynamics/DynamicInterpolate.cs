using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interpolates between the starting position and an end position over a set amount of time.
/// </summary>
public class DynamicInterpolate : MonoBehaviour
{
    /// <summary>
    /// The duration of the interpolation
    /// </summary>
    public float Duration;

    /// <summary>
    /// The endpoint of the interpolation
    /// </summary>
    public Vector2 EndPoint;

    /// <summary>
    /// The start point of the motion
    /// </summary>
    private Vector2 StartPoint;

    /// <summary>
    /// Called to trigger the flash coroutine
    /// </summary>
    public void Interpolate()
    {
        StartPoint = transform.localPosition;
        StopAllCoroutines();
        StartCoroutine(InterpolateRoutine(transform, EndPoint, StartPoint, Duration));
    }

    private static IEnumerator InterpolateRoutine(Transform transform, Vector2 endPoint, Vector2 startPoint, float duration)
    {
        if (duration == 0)
        {
            transform.localPosition = endPoint;
        }
        else
        {
            while (Vector2.Distance(transform.position, endPoint) > 10f)
            {
                var motionVector = (endPoint - startPoint) * Time.deltaTime / duration;
                transform.localPosition += new Vector3(motionVector.x, motionVector.y, 0);
                yield return null;
            }
        }
    }
}
