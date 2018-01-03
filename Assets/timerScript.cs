using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour {

    public Text timerText;
    private float startTime = 0f;
    private string[] resTime;
    private string result;
    private bool finished = false;
    public Text trophy;
    public Toggle[] tog;
    public Text resultTime;
    public int counter=0;
    public GameObject[] trophyImage;
	
	// Update is called once per frame
	void Update () {
        if (finished)
        {
            return;
        }
        for (int i = 0, counter = 0; i < tog.Length; i++)
        {
            if (tog[i].isOn)
            {
                counter++;
            }
            if (counter >= tog.Length)
            {
                finish(timerText.text);
                timerText.enabled = false;
            }
            
        }
        /* if (tog.isOn)
         {
             finish(timerText.text);
             timerText.enabled = false;
         }*/

        startTime += Time.deltaTime;

        int seconds = (int)(startTime % 60);
        int minutes = (int)(startTime / 60) % 60;

        timerText.text = minutes.ToString() + " : " + seconds.ToString("00");
    }
    public void finish(string res)
    {
        string resDisplay = timerText.text;
        resultTime.text = resDisplay;
        resTime = res.Split(':', ' ');
        for (int rest = 0; rest < resTime.Length; rest++)
        {
            if (rest == 0)
            {
                if (resTime[rest] == "0")
                {
                    resTime[rest] = "";
                }
            }
        }
        string a = (string.Join("", resTime));
        int b = int.Parse(a);
        Debug.Log(string.Join("", resTime));
        if (b <= 300)
        {
            trophy.text = "Gold";
            trophyImage[0].SetActive(true);
        }
        else if (b > 300 && b <= 500)
        {
            trophy.text = "Silver";
            trophyImage[1].SetActive(true);
        }
        else
        {
            trophy.text = "Bronze";
            trophyImage[2].SetActive(true);
        }
        finished = true;
    }
}
