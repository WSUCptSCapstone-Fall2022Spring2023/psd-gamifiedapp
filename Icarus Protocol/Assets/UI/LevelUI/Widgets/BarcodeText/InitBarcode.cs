using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitBarcode : MonoBehaviour
{
    /// <summary>
    /// Stores a reference to the text, retrieved on startup
    /// </summary>
    private TMP_Text mTextRef;

    /// <summary>
    /// Timer for numeric change
    /// </summary>
    private float timer;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mTextRef = GetComponent<TMP_Text>();
        mTextRef.text = Random.Range(0, 9999).ToString("0000");
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Update()
    {
        if (timer <= 0)
        {
            mTextRef.text = Random.Range(0, 9999).ToString("0000");
            timer = Random.Range(0.5f, 2.0f);
        }
        timer -= Time.deltaTime;
    }
}
