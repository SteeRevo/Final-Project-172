using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTriggers : MonoBehaviour
{
    public List<GameObject> examineTriggers;
    public List<GameObject> otherOptions;
    
    public void activateTriggers()
    {
        foreach (GameObject triggers in examineTriggers)
        {
            triggers.SetActive(true);
        }
    }

    public void setExit()
    {
        foreach (GameObject options in otherOptions)
        {
            options.SetActive(false);
        }
    }
}
