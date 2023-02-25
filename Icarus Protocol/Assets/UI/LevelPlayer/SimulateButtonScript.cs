using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that controls the behavior of the simulate button.
/// </summary>
public class SimulateButtonScript : MonoBehaviour
{
    /// <summary>
    /// A reference to the IronPythonContainer stored in the parent level UI
    /// </summary>
    public IronPythonContainer IPContainer;

    /// <summary>
    /// A reference to the active phase definition, provided by the parent level controller.
    /// </summary>
    public PhaseDefinition PhaseDefinition;

    /// <summary>
    /// A reference to the ID for getting packaged code
    /// </summary>
    public IDEController IDE;

    public void Execute()
    {
        IPContainer.InitializeLevel(PhaseDefinition);
        IPContainer.Simulate(IDE.GetPlayerCode());
    }


    /// <summary>
    /// Called every frame
    /// </summary>
    public void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S))) 
        {
            Execute();
        }
    }
}
