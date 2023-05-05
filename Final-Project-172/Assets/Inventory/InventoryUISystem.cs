using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUISystem : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotsUI> slots = new List<SlotsUI>();
    // Start is called before the first frame update
    void Start()
    {
        //inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory() {
        if(!inventoryPanel.activeSelf) {
            inventoryPanel.SetActive(true);
            Setup();
            // Setup();
        } else {
            inventoryPanel.SetActive(false);
        }
    }

    public void Setup() {
        if (slots.Count == player.inventory.slots.Count) {
            for (int i = 0; i < slots.Count; i++) {
                if (player.inventory.slots[i].type != CollectableType.NONE) {
                    slots[i].SetItem(player.inventory.slots[i]);
                } else {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
