using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{

    public class TrayLiquidCounter : MonoBehaviour
    {
        public int liquid = 100;
        public int liquidCounter = 0;
        public UnityEvent OnFinished;

        void Update()
        {
            if(liquidCounter >= liquid)
            { 
                this.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
                OnFinished.Invoke();
            }
        }
        void OnParticleCollision(GameObject other)
        {
            Debug.Log(other.name);
            if (other.name == "Tray")
            {
                Debug.Log(other.name);
                GameObject LiquidManager = GameObject.Find("LiquidManager");
                LiquidManager.GetComponent<LiquidManager>().badLiquidAmount -= 1;
                liquidCounter++;
            }
        }
    }
}