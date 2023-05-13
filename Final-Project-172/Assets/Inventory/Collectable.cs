using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    public CollectableType type;
    
    public Sprite icon;
    public GameObject InventoryHolder;
    private Player player;
    private Image collectableItem;
    public void CollectItem() {
        Debug.Log("collected!");
        // Player player = GetComponent<Player>();
        // player.inventory.Add(this);
        player = InventoryHolder.GetComponent<Player>();
        collectableItem = this.gameObject.GetComponent<Image>();
        // Player player = GetComponent<Player>();
        player.inventory.Add(this);
        collectableItem.enabled = false;
    }
}

public enum CollectableType {
        NONE, WALLET, CAR_KEYS
}
