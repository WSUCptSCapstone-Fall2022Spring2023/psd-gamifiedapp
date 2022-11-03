using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDisable : MonoBehaviour
{
    /// <summary>
    /// The time to stay active for.
    /// </summary>
    public float TimeDelay;

    /// <summary>
    /// The timer until self-deactivation.
    /// </summary>
    private float timer;

    /// <summary>
    /// Activates when this component is created.
    /// </summary>
    public void Start()
    {
        timer = TimeDelay;
    }

    /// <summary>
    /// Update is called once each frame
    /// </summary>
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
