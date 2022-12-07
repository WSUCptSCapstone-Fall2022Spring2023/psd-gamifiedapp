using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeListener : MonoBehaviour
{
    /// <summary>
    /// A reference to the UI layout handler for managing transitions.
    /// </summary>
    public UILayoutHandler UIHandler;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (UIHandler.CurrentState != TransitionType.START_MENU && UIHandler.CurrentOverlay != TransitionType.MANUAL)
            {
                UIHandler.TogglePauseMenu(0);
            }
            else if (UIHandler.CurrentOverlay == TransitionType.MANUAL) 
            {
                UIHandler.TransitionToManual(0);
            }
        }
    }
}
