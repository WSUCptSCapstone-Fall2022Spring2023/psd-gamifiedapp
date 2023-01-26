using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

/// <summary>
/// Can be placed on a text gameobject. Will reproject the text onto another text object, while apply syntax highlighting in the process.
/// </summary>
public class SyntaxHighlighting : MonoBehaviour
{
    /// <summary>
    /// The target to project the colored text onto.
    /// </summary>
    public TMP_Text targetText;

    /// <summary>
    /// IronPython container reference for getting this lesson's keywords
    /// </summary>
    public IronPythonContainer IPContainer;

    /// <summary>
    /// The text component on this objct.
    /// </summary>
    private TMP_Text sourceText;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        sourceText = this.GetComponent<TMP_Text>();   
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        string outputText = Regex.Replace(sourceText.text, @"[0-9]+", delegate (Match m) {
            return $"<color=blue>{m.Value}</color>";
        });

        foreach (string variable in IPContainer.mCachedLevel.ExposedMembers) {
            outputText = Regex.Replace(outputText, @"\b" + variable + @"\W", delegate (Match m) {
                return $"<color=red>{m.Value}</color>";
            });
        }

        outputText = Regex.Replace(outputText, @"\b(if|else|elif)\W", delegate(Match m) {
            return $"<color=green>{m.Value}</color>";
        });

        outputText = Regex.Replace(outputText, @"\b(for|while|in)\W", delegate (Match m) {
            return $"<color=magenta>{m.Value}</color>";
        });

        outputText = Regex.Replace(outputText, @"\b(is|and|or)\W", delegate (Match m) {
            return $"<color=yellow>{m.Value}</color>";
        });

        outputText = Regex.Replace(outputText, @"\b(True|False)\W", delegate (Match m) {
            return $"<color=orange>{m.Value}</color>";
        });

        outputText = Regex.Replace(outputText, @"(""|')", delegate (Match m) {
            return $"<color=blue>{m.Value}</color>";
        });

        targetText.text = outputText;
    }
}
