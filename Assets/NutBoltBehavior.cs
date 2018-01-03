using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutBoltBehavior : MonoBehaviour {

    public float timeToSnap;
    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;

        while(transform.parent == null)
        {
            if (currentTime >= timeToSnap)
            {
                // Make this object fall to the ground
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                currentTime = 0;
            }
        }
    }

    IEnumerator OnCollisionEnter(Collision col)
    {
        // On collision with ground, put to BoltsTable
        if(col.gameObject.name == "Terrain" || transform.position.x <= -10)
        {
            yield return new WaitForSeconds(3);
            GameObject boltTable = GameObject.Find("BoltsTable");
            this.gameObject.transform.position = new Vector3(boltTable.transform.position.x, boltTable.transform.position.y + 1f, boltTable.transform.position.z);
            transform.rotation = Quaternion.Euler(0,0,0);

            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
