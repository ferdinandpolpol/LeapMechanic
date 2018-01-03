using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FixedWheelBehavior : MonoBehaviour {

    public int ChildCount;
    public UnityEvent ChildCountSatisfied;
    private bool EventCalled= false;

    void FixedUpdate()
    {
        int totalChild = 0;
        foreach(Transform obj in transform)
        {
            totalChild += 1;
            totalChild += obj.childCount;
        }
        
        if(totalChild == ChildCount && EventCalled == false)
        {
            EventCalled = true;
            ChildCountSatisfied.Invoke();
        }

    }

    public void EnableJack()
    {
        // Remove snapped jack to parent then destroy jack placement, then proceed to replacing snapped jack with hand jack
        GameObject snappedJack = GameObject.Find("snapped_tool_jack");
        GameObject jackPlacement = GameObject.Find("jack_placement");
        GameObject handJack = GameObject.Find("hand" + snappedJack.name.Substring(7));
            
        if (jackPlacement != null)
        {
            snappedJack.transform.parent = snappedJack.transform.parent.gameObject.transform.parent;
        }

        Vector3 snappedJackPos = snappedJack.transform.position;
        snappedJack.transform.position = new Vector3(0, 0, 0);

        Destroy(jackPlacement);
        Debug.Log(snappedJackPos);
        handJack.transform.position = snappedJackPos;
        handJack.transform.rotation = Quaternion.Euler(0, 0, -90);


    }
}
