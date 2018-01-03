using UnityEngine;
using UnityEngine.Events;

public class BoltManager : MonoBehaviour {

    public int UnBoltNeed;
    public int UnBoltedCount = 0;

    public int toBoltNeed;
    public int toBoltCount = 0;
    public UnityEvent UnBoltedDone;
    public UnityEvent ToBoltedDone;
    void Update()
    {
        if(UnBoltedCount >= UnBoltNeed)
        {
            UnBoltedDone.Invoke();
        }
        if(toBoltCount >= toBoltNeed)
        {
            ToBoltedDone.Invoke();
        }
    }

    public void addUnbolted()
    {
        UnBoltedCount += 1;
    }

    public void addToBolt()
    {
        toBoltCount += 1;
    }
}
