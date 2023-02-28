using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum LogTypes { 
    LEVEL_START,
    LEVEL_EXIT,
    PHASE_FAILURE,
    PHASE_SUCCESS,
    MANUAL_ACCESS,
    MANUAL_EXIT
}

/// <summary>
/// Handles the logs for the playtests recording the actions that players take in game for better hard data on play.
/// </summary>
public class PlaytestLogger : MonoBehaviour
{
    /// <summary>
    /// Checked on in the inspector if logging is enabled, false otherwise.
    /// </summary>
    public bool loggingEnabled;

    /// <summary>
    /// Caches the path to the logfile
    /// </summary>
    private string logPath { get; set; }

    /// <summary>
    /// Awake runs when the object is loaded.
    /// </summary>
    void Awake()
    {
        if (loggingEnabled) {
            string savePath = Application.persistentDataPath + $"/logs";
            Directory.CreateDirectory(savePath);
            logPath = savePath + $"/{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}-log.csv";
        }
    }

    /// <summary>
    /// Addes a line to the logfile
    /// </summary>
    public void CreateLog(LogTypes type, string context)
    {
        if (loggingEnabled) {
            File.AppendAllText(logPath, $"{type}, {Time.realtimeSinceStartup}, {context}\n");
            Debug.Log($"Added log entry to {logPath}");
        }
    }
}
