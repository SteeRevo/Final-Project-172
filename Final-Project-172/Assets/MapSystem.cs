using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    public GameObject mapPanel;
    // Start is called before the first frame update
    void Start()
    {
        //inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMap() {
        if(!mapPanel.activeSelf) {
            mapPanel.SetActive(true);
        } else {
            mapPanel.SetActive(false);
        }
    }

    public void changeLocation()
    {
        
    }
}
