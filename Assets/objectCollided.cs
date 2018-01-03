using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollided : MonoBehaviour {

    // Use this for initialization
    public Color normalColor;
    public Color hoverColor;
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().material.color = normalColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "RigidRoundHand_L")
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = hoverColor;
            Debug.Log("Collided");
        }
    }
}
