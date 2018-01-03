using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Tools : MonoBehaviour {

    public float distanceFromCamera;
    public GameObject Tools_List;

    public void spawn_Tool()
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //GameObject tool = Instantiate(Resources.Load("_createdPrefabs/" + Tools_List.name) as GameObject) as GameObject;
        Tools_List.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
    }
}
