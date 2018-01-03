using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipsDialogScript : MonoBehaviour {

	public Text text;
	public string[] strings;
	public float speed = 0.1f;
	public float transition = 10.0f;

	int stringIndex = 0;
	int characterIndex = 0;
	public float timer = 0f;
	// Use this for initialization
	void Start () {
		StartCoroutine (DisplayTimer ());
	}
	IEnumerator DisplayTimer(){
		while (1 == 1) {
			yield return new WaitForSeconds (speed);

			if(characterIndex > strings[stringIndex].Length){
				continue;
			}
			text.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
		}
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= 10.0f) {
			timer = 0f;
			stringIndex++;
			characterIndex = 0;
		}
		if (stringIndex > strings.Length-1) {
			stringIndex = 0;
		}
	}
}
