using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public void ToggleSettings() {
        if(!settingsPanel.activeSelf) {
            settingsPanel.SetActive(true);
        } else {
            settingsPanel.SetActive(false);
        }
    }
}
