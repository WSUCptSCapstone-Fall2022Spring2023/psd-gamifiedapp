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
    /// Defines the color of numeric constants
    /// </summary>
    public Color NumericColor;

    /// <summary>
    /// Defines the color of variable/function keywords
    /// </summary>
    public Color VariableColor;

    /// <summary>
    /// Defines the color of loop keywords (for/while/in)
    /// </summary>
    public Color LoopColor;

    /// <summary>
    /// Defines the color of conditional keywords (if/else/elif)
    /// </summary>
    public Color ConditionalColor;

    /// <summary>
    /// Defines the color of boolean constants
    /// </summary>
    public Color BooleanColor;

    /// <summary>
    /// Defines the color of single and double quotes
    /// </summary>
    public Color QuoteColor;

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
        //Colors numeric constants
        string outputText = Regex.Replace(sourceText.text, @"\b[0-9]+\b", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(NumericColor)}>{m.Value}</color>";
        });

        //Colors variables
        foreach (string variable in IPContainer.mCachedLevel.ExposedMembers) {
            outputText = Regex.Replace(outputText, @"\b" + variable + @"\b", delegate (Match m) {
                return $"<color=#{ColorUtility.ToHtmlStringRGB(VariableColor)}>{m.Value}</color>";
            });
        }

        //Colors parentheses
        outputText = Regex.Replace(outputText, @"(\(|\))", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(VariableColor)}>{m.Value}</color>";
        });

        //Colors conditional keywords
        outputText = Regex.Replace(outputText, @"\b(if|else|elif)\b", delegate(Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(ConditionalColor)}>{m.Value}</color>";
        });

        //Colors loop keyowrds
        outputText = Regex.Replace(outputText, @"\b(for|while|in)\b", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(LoopColor)}>{m.Value}</color>";
        });

        //Colors conditional operators
        outputText = Regex.Replace(outputText, @"\b(is|and|or)\b", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(ConditionalColor)}>{m.Value}</color>";
        });

        //Colors boolean keywords
        outputText = Regex.Replace(outputText, @"\b(True|False)\b", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(BooleanColor)}>{m.Value}</color>";
        });

        //Colors quotes 
        outputText = Regex.Replace(outputText, @"(""|')", delegate (Match m) {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(QuoteColor)}>{m.Value}</color>";
        });

        targetText.text = outputText;
    }
}
