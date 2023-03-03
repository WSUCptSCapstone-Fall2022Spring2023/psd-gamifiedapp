using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomly repositioned within a certain radius of the centerpoint position
/// </summary>
public class DynamicReposition : MonoBehaviour
{
    /// <summary>
    /// The centerpoint to select positions around.
    /// </summary>
    public Vector2 Center;

    /// <summary>
    /// The maximum distance from the centerpoint to select
    /// </summary>
    public float MaxDistance;

    /// <summary>
    /// The delay between each movement.
    /// </summary>
    public float Delay;

    /// <summary>
    /// The time counter for movements.
    /// </summary>
    private float timer;

    /// <summary>
    /// Update is called each frame
    /// </summary>
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > Delay)
        {
            transform.localPosition = new Vector3(Random.Range(Center.x - MaxDistance, Center.x + MaxDistance), Random.Range(Center.y - MaxDistance, Center.y + MaxDistance), 0);
            timer = 0;
        }
    }
}
