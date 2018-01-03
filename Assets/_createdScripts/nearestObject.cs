using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{

    public class nearestObject : MonoBehaviour
    {

        [Header("Color Behavior")]
        public Color normalColor;   //Starting Color of the object
        public Color hoverColor;    //Color when an object with tag is hovered
        public float hoverDistance; //Hover Distance

        public GameObject[] toolsUsable;

        public UnityEvent OnHover; 

        private followHandTest onHand;
        private GameObject tool = null;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            float nearestDistance = hoverDistance;
            GameObject temp = null;
            foreach (GameObject obj in toolsUsable)
            {
                if (obj != null)
                {
                    float distance = (transform.position - obj.transform.position).sqrMagnitude;

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        tool = temp = obj;

                        onHand = tool.GetComponent<followHandTest>();

                        if (onHand.enabled == false)
                        {
                            stickOnHover();
                        }
                    }
                }
            }

            // Changes the color of the object
            if (temp != null)
            {
                this.gameObject.GetComponent<Renderer>().material.color = hoverColor;
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material.color = normalColor;
            }
        }

        // Create a function that sticks the objects when <=hoverDistance
        void stickOnHover()
        {
            if (this.gameObject.transform.childCount > 0)
            {

            }
            else
            {
                OnHover.Invoke();
            }
        }

        public void EnableToolSpin()
        {

            string newTool = "snapped" + tool.name.Substring(4);
            GameObject snappedTool = GameObject.Find(newTool);

            if (snappedTool.GetComponent<ToolSpinBehavior>() != null)
            {
                snappedTool.GetComponent<ToolSpinBehavior>().enabled = true;
            }
        }
        public void EnableToolSpinGameObject(GameObject obj)
        {
            if (obj.GetComponent<ToolSpinBehavior>() != null)
            {
                obj.GetComponent<ToolSpinBehavior>().enabled = true;
            }
        }

        public void FindSnapTool()   //Finds the object "snapped" tool and snap it
        {
            string newTool = "snapped" + tool.name.Substring(4);
            if (tool != null)
            {
                tool.transform.position = new Vector3(0, 0, 0);
                GameObject snappedTool = GameObject.Find(newTool);

                snappedTool.transform.parent = this.gameObject.transform;
                snappedTool.transform.position = this.gameObject.transform.position;
            }
        }

        public void DirectSnap() //Directly snaps the object to the object
        {
            if (tool != null)
            {
                tool.transform.parent = this.gameObject.transform;
                tool.transform.position = this.gameObject.transform.position;

            }
        }

        public void RemoveRigidbodyofObject()
        {
            Destroy(tool.GetComponent<Rigidbody>());
        }

        public void ConstraintObject()
        {
            Rigidbody rigidbody = tool.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        public void EnableToolSnapping()
        {
            tool.GetComponent<nearestObject>().enabled = true;
        }

        public void EnableNutBolt()
        {
            tool.GetComponent<NutBoltBehavior>().enabled = true;
        }

        public void RotateToolOnX(float x)
        {
            string newTool = "snapped" + tool.name.Substring(4);
            if (tool != null)
            {
                GameObject snap = GameObject.Find(newTool);
                snap.transform.rotation = Quaternion.Euler(x, snap.transform.rotation.y, snap.transform.rotation.z);
            }
        }
        public void RotateToolOnY(float y)
        {
            string newTool = "snapped" + tool.name.Substring(4);
            if (tool != null)
            {
                GameObject snap = GameObject.Find(newTool);
                snap.transform.rotation = Quaternion.Euler(snap.transform.rotation.x, y, snap.transform.rotation.z);
            }
        }
        public void RotateToolOnZ(float z)
        {
            string newTool = "snapped" + tool.name.Substring(4);
            if (tool != null)
            {
                GameObject snap = GameObject.Find(newTool);
                snap.transform.rotation = Quaternion.Euler(snap.transform.rotation.x, snap.transform.rotation.y, z);
            }
        }
        public void FindSpecificSnapTool(GameObject obj)
        {
            tool.transform.position = new Vector3(0, 0, 0);
            obj.transform.parent = this.gameObject.transform;
            obj.transform.position = this.gameObject.transform.position;
        }

        public void DisableHandTool()
        {
            tool.SetActive(false);
        }
    }
}