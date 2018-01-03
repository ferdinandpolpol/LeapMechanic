using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationLock : MonoBehaviour {

    public bool xAxis;
    public bool yAxis;
    public bool zAxis;

    void Start () {
        float lockPos = 0;
        if (xAxis)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;
        }
        if (yAxis)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;
        }
        if (zAxis)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(lockPos, lockPos, transform.rotation.eulerAngles.z);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePosition;
        }
    }
}
