using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilDrainBehavior : MonoBehaviour {

    public int childCount = 2;
    public GameObject particle;

    private bool isActivated = false;

    void FixedUpdate()
    {
        if (transform.childCount == childCount && isActivated == false)
        {
            particle.GetComponent<ParticleSystem>().enableEmission = true;
            isActivated = true;
        }
        else
        {
            particle.GetComponent<ParticleSystem>().enableEmission = false;
            isActivated = false;
        }
    }
}
