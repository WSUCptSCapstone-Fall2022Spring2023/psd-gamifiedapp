using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

/// <summary>
/// Controls the AIOuput text box in the bottom left to print feedback and conversations.
/// </summary>
public class OutputController : MonoBehaviour
{
    /// <summary>
    /// A reference to the sequential typer of the script box that the output handler will print to.
    /// </summary>
    public SequentialTyper Text;

    /// <summary>
    /// The prompts that are run through when the phase loads
    /// </summary>
    private List<string> ScriptPrompts { get; set; } = new List<string>();

    /// <summary>
    /// The resopnses to various failures, in the order of the error codes.
    /// </summary>
    private List<string> FailureResponses { get; set; } = new List<string>();

    /// <summary>
    /// Initializes the script prompts and failure responses
    /// </summary>
    public void InitializeScript(TextAsset scriptFile) 
    {
        List<string> splitList = scriptFile.text.Split("\n", System.StringSplitOptions.RemoveEmptyEntries).ToList();
        ScriptPrompts = splitList.Where(e => !e.StartsWith("~")).ToList();
        FailureResponses = splitList.Where(e => e.StartsWith("~")).Select(e => e[1..]).ToList();
    }

    /// <summary>
    /// Prints the next element of the main script prompts.
    /// </summary>
    public void AdvanceScript() 
    {
        //TODO: Make this advance through multiple prompts once conversations are added.
        Text.GiveTypingJob(ScriptPrompts[0]);
    }

    /// <summary>
    /// Prints the failure associated with a certain error code.
    /// </summary>
    /// <param name="exitCode">The exit code to print the message associated with.</param>
    public void PrintFailureResponse(int exitCode) 
    {
        Text.GiveTypingJob(FailureResponses[exitCode - 1]);
    }
}
