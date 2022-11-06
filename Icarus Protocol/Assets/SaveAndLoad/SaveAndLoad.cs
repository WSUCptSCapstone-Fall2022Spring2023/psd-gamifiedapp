using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        GameObject[] levels = GameObject.FindGameObjectsWithTag("Level");
        foreach (GameObject level in levels) 
        {
            ProgressRecord progressRecord = level.GetComponent<ProgressRecord>();
            PhaseDefinition[] phaseDefinitions = level.GetComponents<PhaseDefinition>();
            foreach (PhaseDefinition phase in phaseDefinitions) 
            {
                progressRecord.PhaseCompletion.Add(new ProgressRecord.PhaseProgress() { PhaseComplete = false, PhaseID=phase.ID });
            }
        }
    }
}
