using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows an art piece to dynamically rotate at a set speed while script is enabled.
/// </summary>
public class DynamicRotate : MonoBehaviour
{
    /// <summary>
    /// The number of full cycles to complete each second.
    /// </summary>
    public float RotationSpeed;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        transform.Rotate(this.transform.forward, RotationSpeed * Time.deltaTime * 360);
    }
}
