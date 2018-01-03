using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public Camera MainCamera;
    public new Camera[] camera;

    private int currentCamera =0;
	void Update () {
        MainCamera.transform.position = camera[currentCamera].transform.position;
        MainCamera.transform.rotation = camera[currentCamera].transform.rotation;
	}

    public void TransferCameraUp()
    {
        currentCamera += 1;
        if(currentCamera >= camera.Length)
        {
            currentCamera = 0;
        }

    }
    public void TransferCameraDown()
    {
        currentCamera += 1;
        if (currentCamera < 0)
        {
            currentCamera = camera.Length;
        }
    }
}
