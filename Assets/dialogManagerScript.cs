using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogManagerScript : MonoBehaviour
{

    public TextAsset samTxt;
    public GameObject textBox;
    public GameObject canvas;
    public Text theText;
    public Toggle[] toggle;
    public string[] textLines;
    // Use this for initialization
    void Start()
    {
        if (samTxt != null)
        {
            textLines = (samTxt.text.Split('\n'));
        }
        for (int i = 0; i < textLines.Length; i++)
        {
            toggle[i].GetComponentInChildren<Text>().text = textLines[i];
        }
    }

    public void PromptBehavior()
    {
        if (canvas.activeInHierarchy == true)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }
}
