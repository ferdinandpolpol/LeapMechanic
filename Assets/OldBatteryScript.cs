using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OldBatteryScript : MonoBehaviour {

    public Toggle[] toggle;

    public UnityEvent OnFinished;

    void Update()
    {
        // Check if all the toggles are finished then do something
        for(int i = 0; i <= toggle.Length - 1; i++)
        {
            if (!toggle[i].isOn)
            {
                break;
            }
            else
            {
                if (i >= toggle.Length - 1)
                {
                    Debug.Log("Finished");
                    OnFinished.Invoke();
                }
            }
            Debug.Log("i: " + i + " toggleLength: " + (toggle.Length - 1));
        }
    }
}
