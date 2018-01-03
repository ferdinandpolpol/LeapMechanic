using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour {

    public int counter = 0;

	void Update()
    {
        transform.localPosition = new Vector3(0,0,counter);
        counter++;
    }
}
