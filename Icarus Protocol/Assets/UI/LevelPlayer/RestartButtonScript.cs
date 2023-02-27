using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour
{
    /// <summary>
    /// A reference to the IDEController for reseting the starter code.
    /// </summary>
    public IDEController IDERef;

    /// <summary>
    /// Called when the button is clicked.
    /// </summary>
    public void OnClick()
    {
        IDERef.ReinitStarterCode();
    }
}
