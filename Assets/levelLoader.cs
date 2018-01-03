using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;
	public GameObject playButton;
	public GameObject[] procPrompt;
	public bool loadingFinished = false;
	public int counter;
	public AsyncOperation operation;

	public void LoadLevel(int sceneIndex)
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);
		counter = 0;

		if (sceneIndex == 1)
		{
			procPrompt[0].SetActive(true);
		}
		else if(sceneIndex == 2)
		{
			procPrompt[1].SetActive(true);
		}
        else if (sceneIndex == 3)
        {
            procPrompt[2].SetActive(true);
        }
        else if (sceneIndex == 4)
        {
            procPrompt[3].SetActive(true);
        }
        else if (sceneIndex == 5)
        {
            procPrompt[4].SetActive(true);
        }
        else if (sceneIndex == 6)
        {
            procPrompt[5].SetActive(true);
        }
        else if (sceneIndex == 7)
        {
            procPrompt[6].SetActive(true);
        }
        else if (sceneIndex == 8)
        {
            procPrompt[7].SetActive(true);
        }
        else if (sceneIndex == 9)
        {
            procPrompt[8].SetActive(true);
        }
        while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			slider.value = progress;
			operation.allowSceneActivation = false;
			if (slider.value == 1) {
				slider.gameObject.SetActive (false);
				playButton.SetActive (true);
				if (counter == 1) {
					operation.allowSceneActivation = true;
				}
			}
			yield return null;
		}
	}
	public void onClick(){
		counter = 1;
	}
}
