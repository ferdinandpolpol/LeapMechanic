using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    public class output : MonoBehaviour
    {

        // Use this for initialization
        int graspCounter;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void onActivate()
        {
            graspCounter++;
            Debug.Log("Nigana - " + graspCounter);
        }
    }
}