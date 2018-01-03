using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Script will show the names of the objects that the right hand is hovering.
namespace Leap.Unity.Interaction
{
    public class ObjectNameInterface : MonoBehaviour
    {
        public string ObjectName = "";
        public float HoverDistance = 0.5f;

        [Space]
        public IHandModel HandModel;
        public Text TextBox;

        void Update()
        {
            Hand MainHand = HandModel.GetLeapHand();
            if(MainHand != null)
            {
                float distance = (transform.position - MainHand.PalmPosition.ToVector3()).sqrMagnitude;

                if (distance <= HoverDistance)
                {
                    TextBox.text = ObjectName;
                }
                else
                {
                    TextBox.text = "";
                }
            }
            else
            {
                TextBox.text = "";  
            }
        }
    }
}

