using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class ToolSpinBehavior : MonoBehaviour {

        public int spinsNeeded;
        public IHandModel HandModel;

        //Determines what axis the object will spin on
        public bool rotateOnX = false;
        public bool rotateOnY = false;
        public bool rotateOnZ = false;

        public UnityEvent ClockWiseSpinDone = new UnityEvent();
        public UnityEvent CounterClockWiseSpinDone = new UnityEvent();

        private float angle = 0.0f;
        private float rotationAmount = 0.0f;
        private GameObject BoltsTable;

        void Start()
        {
            BoltsTable = GameObject.Find("BoltsTable");
        }

        void Update()
        {
            Hand hand = HandModel.GetLeapHand();
            if (hand != null)
            {
                /*
                 * This line of codes are used for determining angle between hand and object
                 * The objects rotation will follow the hand.
                 * 
                 */
                Vector3 objectPos = transform.position;
                Vector3 handPos = hand.PalmPosition.ToVector3();
                if (rotateOnX)
                {
                    float newAngle = Mathf.Atan2(objectPos.z - handPos.z, objectPos.y - handPos.y) * Mathf.Rad2Deg;
                    rotationAmount += Mathf.DeltaAngle(angle, newAngle);
                    angle = newAngle;
                    transform.rotation = Quaternion.Euler(new Vector3(newAngle, transform.rotation.y, transform.rotation.z));
                }
                else if (rotateOnY)
                {
                    float newAngle = Mathf.Atan2(objectPos.x - handPos.x, objectPos.z - handPos.z) * Mathf.Rad2Deg;
                    rotationAmount -= Mathf.DeltaAngle(angle, newAngle);
                    angle = newAngle;
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, newAngle, transform.rotation.z));
                }
                else if (rotateOnZ)
                {
                    float newAngle = Mathf.Atan2(objectPos.y - handPos.y, objectPos.x - handPos.x) * Mathf.Rad2Deg;
                    rotationAmount -= Mathf.DeltaAngle(angle, newAngle);
                    angle = newAngle;
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, newAngle));
                }
                // Determines if the tool has spun from the given amount
                if ((rotationAmount / 360) >= spinsNeeded && this.gameObject.transform.parent != null)
                {
                    rotationAmount = 0;
                    angle = 0.0f;

                    ClockWiseSpinDone.Invoke();
                    this.enabled = false;
                }
                else if ((rotationAmount / 360) <= -spinsNeeded && this.gameObject.transform.parent != null)
                {
                    rotationAmount = 0;
                    angle = 0.0f;
                    CounterClockWiseSpinDone.Invoke();
                    this.enabled = false;
                }
            }
        }

        public void DisableObjectSnapping() // Disable snapping of tools of the parent object
        {
            if(transform.parent.gameObject.GetComponent<nearestObject>() != null)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<nearestObject>().enabled = false;
            }
        }

        public void AddRigidbodytoParent()  // Add rigidbody to make the bolt fall
        {
            this.gameObject.transform.parent.gameObject.AddComponent<Rigidbody>();
        }

        public void RemoveParentConstraints()
        {
            Rigidbody rigidbody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.None;
        }

        public void RemoveBoltFromParent()  // Remove the bolt from the wheel
        {
            Debug.Log(this.gameObject.transform.parent.gameObject.name  );
            this.gameObject.transform.parent.gameObject.transform.parent = null;
        }

        public void TransferBolttoBoltsTable() // Transfer Bolts to the tbale
        {
            if(BoltsTable != null)
            {
                this.gameObject.transform.parent.gameObject.transform.parent = BoltsTable.transform;
                this.gameObject.transform.parent.gameObject.transform.position = new Vector3(BoltsTable.transform.position.x, BoltsTable.transform.position.y + .2f, BoltsTable.transform.position.z);
            }
        }

        public void EnableFollowHand()
        {
            this.gameObject.transform.parent.gameObject.GetComponent<followHandTest>().enabled = true;
        }

        public void FinalizeBolts()
        {
            
        }

        public void RemovethisFromParent()
        {
            this.gameObject.transform.parent = null;
        }   

        public void TransferthisToBoltsTable()
        {
            if (BoltsTable != null)
            {
                this.gameObject.transform.parent = BoltsTable.transform;
                this.gameObject.transform.position = new Vector3(BoltsTable.transform.position.x, BoltsTable.transform.position.y + .2f, BoltsTable.transform.position.z);
            }
        }

        public void RemoveConstraints()
        {
            Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.None;
        }
        public void EnableInteraction()
        {
            if(this.gameObject.transform.parent.gameObject.GetComponent<InteractionBehaviour>() != null)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<InteractionBehaviour>().enabled = true;
            }
        }

        public void FreezeParentRotation()
        {
            Debug.Log(transform.parent.gameObject.name);
            Rigidbody rigidbody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            rigidbody.velocity = new Vector3(0,0,0);
        }
        
    }
}