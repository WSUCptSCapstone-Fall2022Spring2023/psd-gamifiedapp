using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSlowRotation : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(this.transform.position, this.transform.up, rotationSpeed * Time.deltaTime);
    }
}
