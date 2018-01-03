using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillScript : MonoBehaviour {

    public float totalBar;
    public float currentBar;
    public Image image;
    // Use this for initialization
    void Start()
    {
        currentBar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        increaseBar();
        GameObject LiquidManager = GameObject.Find("LiquidManager");
		if (LiquidManager.GetComponent<LiquidManager>().newLiquidAmount >= totalBar)
        {
			LiquidManager.GetComponent<LiquidManager>().newLiquidAmount = totalBar;
        }
    }
    void increaseBar()
    {
        GameObject LiquidManager = GameObject.Find("LiquidManager");
        image.rectTransform.localScale = new Vector3(0.33729f, (LiquidManager.GetComponent<LiquidManager>().newLiquidAmount / totalBar), 1f);
    }
}
