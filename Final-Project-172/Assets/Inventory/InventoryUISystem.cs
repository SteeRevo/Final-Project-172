using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUISystem : MonoBehaviour
{
     public GameObject inventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory() {
        if(!inventoryPanel.activeSelf) {
            inventoryPanel.SetActive(true);
        } else {
            inventoryPanel.SetActive(false);
        }
    }
}
