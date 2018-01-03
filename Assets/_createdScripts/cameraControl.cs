using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public Camera mainCamera;
	// Update is called once per frame
	void Update () {
        moveCamera();
	}

    void moveCamera()
    {
        mainCamera.transform.Translate(Vector3.forward);
    }
}
