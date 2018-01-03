
using UnityEngine;
using UnityEngine.Events;

public class EngineCoverScript : MonoBehaviour {

    public int count;
    public UnityEvent OnCount;
	// Update is called once per frame
	void Update () {
		if(transform.childCount <= count)
        {
            OnCount.Invoke();
        }
	}

}
