using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drainScript : MonoBehaviour {

    public float totalBar;
    public float currentBar;
    public Image image;
    // Use this for initialization
	void Start () {
        currentBar = totalBar;
	}
	
	// Update is called once per frame
	void Update () {
        takeBar();
        increaseBar();
        GameObject LiquidManager = GameObject.Find("LiquidManager");
        if (LiquidManager.GetComponent<LiquidManager>().badLiquidAmount <= 0)
        {
            LiquidManager.GetComponent<LiquidManager>().badLiquidAmount = 0;
        }
		if (LiquidManager.GetComponent<LiquidManager> ().newLiquidAmount >= totalBar) {
			LiquidManager.GetComponent<LiquidManager>().badLiquidAmount = totalBar;
		}
    }
    void takeBar()
    {
        GameObject LiquidManager = GameObject.Find("LiquidManager");
		image.rectTransform.localScale = new Vector3(0.33729f, (LiquidManager.GetComponent<LiquidManager>().badLiquidAmount/ totalBar), 1f);

    }
    void increaseBar()
    {
       // GameObject LiquidManager = GameObject.Find("LiquidManager");
        //image.rectTransform.localScale = new Vector3(0.33729f, (LiquidManager.GetComponent<LiquidManager>().badLiquidAmount / totalBar), 1f);
    }


}
