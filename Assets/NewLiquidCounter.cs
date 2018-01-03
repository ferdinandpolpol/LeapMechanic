using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class NewLiquidCounter : MonoBehaviour
    {

        public GameObject target;
        public float limit = 999f;
        public UnityEvent OnFinished;
        private float counter = 0;

        void Update()
        {
            if(counter >= limit)
            {
                this.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
                OnFinished.Invoke();
            }
        }
        void OnParticleCollision(GameObject other)
        {
            Debug.Log(other.name);
            if (other.name == target.name)
            {
                GameObject LiquidManager = GameObject.Find("LiquidManager");
                LiquidManager.GetComponent<LiquidManager>().newLiquidAmount += 1;
                counter++;
            }
        }
    }
}