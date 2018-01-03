using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fadeManager : MonoBehaviour {

    public static fadeManager Instance { set; get; }

    public GameObject canvas;
    public Image fadeImage;
    public Text text;
    public Text trophy;
    public Toggle[] tog;
    private bool isInTransition;
    private bool isShowing;
    private float transition;
    private float duration;
    private int ToggleCounter = 0;
    private int ToggleChecker = 0;
    public Image[] bar;
    public Text[] txt;
    public float timer = 15f;
    public string loadToLevel;

    private void Awake()
    {
        Instance = this;

    }
    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }
    // Update is called once per frame
    void Update ()
    {
        /*if (tog.isOn)
        {
            canvas.SetActive(false);
        }
        else if (!tog.isOn)
        {
            Fade(true, 3f);
        }*/
        /*fade out
		if(counter >= 1)
		{
			if (Input.GetKeyDown("space"))
			{
				Fade(false, 1f);
				counter = 0;
			}     
		}*/
        for (int i = 0, counter = 0; i < tog.Length; i++)
        {
            if (tog[i].isOn)
            {
                counter++;
            }
            if (counter >= tog.Length)
            {
                timer -= Time.deltaTime;
                canvas.SetActive(false);
                Fade(false, 3f);
                foreach (Image img in bar)
                {
                    img.enabled = false;
                }
                if(timer <= 0)
                {
                    Application.LoadLevel(loadToLevel);
                }
            }
        }
        if (!isInTransition)
            return;
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        text.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);
        trophy.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        txt[0].color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        txt[1].color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);
        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
        }

    }
}
