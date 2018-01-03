using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    public class ReplacementWheelBehavior : MonoBehaviour
    {

        void Update()
        {
            // Checks if all bolts are taken off then enabling interaction
            if (this.gameObject.transform.childCount == 2)
            {
                this.gameObject.GetComponent<InteractionBehaviour>().enabled = true;
            }
            else
            {
                this.gameObject.GetComponent<InteractionBehaviour>().enabled = false;
            }
        }
    }

}
