using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class followHandTest : MonoBehaviour
    {

        // Use this for initialization
        public IHandModel HandModel;
        public GameObject toolModel;

        void Update()
        {
            Hand hand = HandModel.GetLeapHand();

            if (hand != null)
            {
                this.gameObject.transform.position = hand.PalmPosition.ToVector3();
                this.gameObject.transform.rotation = Quaternion.LookRotation(hand.PalmNormal.ToVector3(), hand.Direction.ToVector3()); //Default Code
            }   
        }
    }
}
