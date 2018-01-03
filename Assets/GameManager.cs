using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction.Internal;
using UnityEngine;
using UnityEngine.Events;
using Leap.Unity.Query;

namespace Leap.Unity.Interaction
{

    public class GameManager : MonoBehaviour
    {
        public void TransferObjectToBoltsTable(GameObject obj)
        {
            GameObject BoltsTable = GameObject.Find("BoltsTable");
            obj.transform.position = new Vector3(BoltsTable.transform.position.x, BoltsTable.transform.position.y + 0.5f, BoltsTable.transform.position.z);
        }

        public void increaseJackLift(float height)
        {
            //Increase the jacklift
            GameObject jackLift = GameObject.Find("SpiralJackLift");
            jackLift.transform.position = new Vector3(jackLift.transform.position.x, jackLift.transform.position.y + height, jackLift.transform.position.z);
        }

        public void EnableInteractionBehavior(GameObject obj)
        {
            obj.GetComponent<InteractionBehaviour>().enabled = true;
        }

        public void EnableConstraints(GameObject obj)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        public void DisableConstraints(GameObject obj)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
        }

        public void RemovefromParent(GameObject obj)
        {
            if(obj.transform.parent != null)
            {
                obj.transform.parent = null;
            }
        }
        public void DestroyObject(GameObject obj)
        {
            if(GameObject.Find(obj.name) != null)
            {
                Destroy(obj);
            }
        }

        public void ResetPosition(GameObject obj)
        {
            obj.transform.position = new Vector3(0,0,0);
        }

        public void EnableEmission(GameObject particle)
        {
            if(particle != null)
            {
                particle.GetComponent<ParticleSystem>().enableEmission = true;
            }
        }
        public void DisableEmission(GameObject particle)
        {
            if (particle != null)
            {
                particle.GetComponent<ParticleSystem>().enableEmission = false;
            }
        }

        public void DecreaseLiquid(int liquid)
        {
            if(GameObject.Find("LiquidManager") != null)
            {
                GameObject liquidManager = GameObject.Find("LiquidManager");
                liquidManager.GetComponent<LiquidManager>().badLiquidAmount -= liquid;
            }
        }

        public void EnableGameObject(GameObject obj)
        {
            obj.SetActive(true);
        }
        
    }
}