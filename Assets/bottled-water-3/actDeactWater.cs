using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actDeactWater : MonoBehaviour {
    
    public float EmissionValue = 0.05f;
	public GameObject bottle;
	public GameObject particle;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float z = bottle.transform.rotation.z;
		if (z > EmissionValue) {
			particle.GetComponent<ParticleSystem> ().enableEmission = true;
		} 
		else {
			//particle.transform.position = new Vector3 (particle.transform.position.x, particle.transform.position.y, particle.transform.position.z);//new Vector3 (0f, 5.0f, 0f);
			//particle.transform.rotation = bottle.transform.rotation;//new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
			particle.GetComponent<ParticleSystem> ().enableEmission = false;

		}

	}
}
