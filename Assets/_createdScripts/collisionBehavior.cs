using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionBehavior : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision collision)
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
