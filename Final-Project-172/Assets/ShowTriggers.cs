using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTriggers : MonoBehaviour
{
    public List<GameObject> ActiveTriggers;
    public List<GameObject> DeactiveTriggers;
    public List<Button>     ActiveButtons;
    public List<Button>     UnactiveButtons;
    
    public void activateTriggers()
    {
        foreach (GameObject triggers in ActiveTriggers)
        {
            triggers.SetActive(true);
        }
        foreach (Button _button in ActiveButtons)
        {
            _button.enabled = true;
        }
    }

    public void deactivateTriggers()
    {
        foreach (GameObject options in DeactiveTriggers)
        {
            options.SetActive(false);
        }
        foreach (Button _button in UnactiveButtons)
        {
            _button.enabled = false;
        }
    }
}
