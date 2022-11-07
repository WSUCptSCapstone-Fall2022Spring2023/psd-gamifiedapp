using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

public class SaveAndLoad : MonoBehaviour
{
    /// <summary>
    /// A list of all of the progress records loaded into the scene, cached for quicker saving.
    /// </summary>
    private List<ProgressRecord> progressRecords = new List<ProgressRecord>();

    /// <summary>
    /// Awake runs when the object is loaded.
    /// </summary>
    void Awake()
    {
        GameObject[] levels = GameObject.FindGameObjectsWithTag("Level");
        foreach (GameObject level in levels) 
        {
            LevelDescription levelDescription = level.GetComponent<LevelDescription>();
            ProgressRecord progressRecord = levelDescription.LevelProgress;
            progressRecord.LevelID = levelDescription.LevelID;
            progressRecords.Add(progressRecord);
            PhaseDefinition[] phaseDefinitions = level.GetComponents<PhaseDefinition>();
            foreach (PhaseDefinition phase in phaseDefinitions) 
            {
                progressRecord.PhaseCompletion.Add(new ProgressRecord.PhaseProgress() { PhaseComplete = false, PhaseID=phase.ID });
            }
        }

        LoadProgress();
    }

    /// <summary>
    /// Saves the current state of all Progress Records as a JSON object to the saves folder.
    /// </summary>
    public void Save() 
    {
        string saveText = JsonConvert.SerializeObject(progressRecords);
        string savePath = Application.persistentDataPath + $"/saves";
        Directory.CreateDirectory(savePath);
        File.WriteAllText(savePath + $"/autosave", saveText);
        Debug.Log($"Saved autosave to {savePath}");
    }

    /// <summary>
    /// Overwrites game progress with data from autosave.
    /// </summary>
    public void LoadProgress() 
    {
        if (File.Exists(Application.persistentDataPath + $"/saves/autosave")) 
        {
            List<ProgressRecord> loadedRecords = JsonConvert.DeserializeObject<List<ProgressRecord>>(File.ReadAllText(Application.persistentDataPath + $"/saves/autosave"));
            foreach (ProgressRecord record in loadedRecords) 
            {
                //Update all associated levels
                ProgressRecord associatedRecord = progressRecords.FirstOrDefault(e => e.LevelID == record.LevelID);
                if (associatedRecord != null) 
                {
                    associatedRecord.LevelComplete = record.LevelComplete;
                    foreach (ProgressRecord.PhaseProgress phase in record.PhaseCompletion) 
                    {
                        //Update all associated phases
                        ProgressRecord.PhaseProgress associatedPhase = associatedRecord.PhaseCompletion.FirstOrDefault(e => e.PhaseID == phase.PhaseID);
                        if (associatedPhase != null) 
                        {
                            associatedPhase.PhaseComplete = phase.PhaseComplete;
                        }
                    }
                }
            }
        }
    }
}
