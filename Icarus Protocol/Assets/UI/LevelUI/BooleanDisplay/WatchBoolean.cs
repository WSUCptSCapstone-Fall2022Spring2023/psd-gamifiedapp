using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatchBoolean : MonoBehaviour
{
    /// <summary>
    /// The name of the Python member to target
    /// </summary>
    public string MemberName;

    /// <summary>
    /// The background image for when the display is on.
    /// </summary>
    public Sprite OnImage;

    /// <summary>
    /// The background display for when the display is off
    /// </summary>
    public Sprite OffImage;

    /// <summary>
    /// The text color for when the display is on.
    /// </summary>
    public Color OnColor;

    /// <summary>
    /// The text color for when the display is off.
    /// </summary>
    public Color OffColor;

    /// <summary>
    /// Stores a ref to the controller to allow it to get necessary information
    /// </summary>
    private PhaseUIController mParent;

    /// <summary>
    /// Stores a ref to the text that the script targets, should be placed on the same object.
    /// </summary>
    private TMP_Text mText;

    /// <summary>
    /// A reference to the panel background image.
    /// </summary>
    public Image PanelRef;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mText = GetComponent<TMP_Text>();
        mParent = GetComponentInParent<PhaseUIController>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        bool value = mParent?.IPContainer.GetPythonValue(MemberName);
        if (value)
        {
            PanelRef.sprite = OnImage;
            mText.color = OnColor;
        }
        else 
        {
            PanelRef.sprite = OffImage;
            mText.color = OffColor;
        }
    }
}
