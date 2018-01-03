using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class WheelManager : MonoBehaviour {

        public UnityEvent OnUnscrew;
        void Update() {
            if (transform.childCount == 0)
            {
                if (transform.GetComponent<InteractionBehaviour>() != null)
                {
                    OnUnscrew.Invoke();
                }
            }
        }
    }
}