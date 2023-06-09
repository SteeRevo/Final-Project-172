using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredits : MonoBehaviour
{

    public GameObject creditsPanel;
    public void ToggleCreditsFunc() {
        if(!creditsPanel.activeSelf) {
            creditsPanel.SetActive(true);
            // Setup();
        } else {
            creditsPanel.SetActive(false);
        }
    }
}
