using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partCol : MonoBehaviour {

	public int count = 0;
	public GameObject particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 100) {
			particle.GetComponent<ParticleSystem> ().enableEmission = false;
		}
	}
	void OnParticleCollision(GameObject other){
		count += 1;
		Debug.Log (count);

	}
}
