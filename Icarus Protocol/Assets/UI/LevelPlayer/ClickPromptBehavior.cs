using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickPromptBehavior : MonoBehaviour
{
    /// <summary>
    /// Stores a reference to the output window script so that this component can hide if it's not possible to move forward.
    /// </summary>
    public OutputController OutputWindowRef;

    /// <summary>
    /// Stores a reference to the text.
    /// </summary>
    private TMP_Text textRef;

    /// <summary>
    /// Called when object is loaded into the scene
    /// </summary>
    public void Start()
    {
        textRef = GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    void Update()
    {
        textRef.color = OutputWindowRef.CanAdvanceFurther ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
    }
}
