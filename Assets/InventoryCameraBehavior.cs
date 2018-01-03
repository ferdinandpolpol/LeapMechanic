using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCameraBehavior : MonoBehaviour {

    // The purpose of this code is to make this InventoryCamera to always follow the position of the Main Camera

    public GameObject mainCamera = Camera.main.gameObject;

    void Update()
    {
        this.gameObject.transform.position = mainCamera.transform.position;
        this.gameObject.transform.rotation = mainCamera.transform.rotation;
    }
}
