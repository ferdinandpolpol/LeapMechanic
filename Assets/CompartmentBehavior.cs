using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompartmentBehavior : MonoBehaviour {

    private Vector3 minRotation;

	void Start () {
        minRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.rotation.x <= minRotation.x)
        {
            transform.rotation = Quaternion.Euler(minRotation);
        }
        else if(transform.rotation.x >= 100)
        {
            transform.rotation = Quaternion.Euler(100, transform.rotation.y, transform.rotation.z);
        }
	}
}
