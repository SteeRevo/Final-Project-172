using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    public CollectableType type;
    public Image collectableItem;
    public Sprite icon;
    public GameObject InventoryHolder;
    public Player player;

    public void CollectItem() {
        Debug.Log("collected!");
        // Player player = GetComponent<Player>();
        // player.inventory.Add(this);
        player = InventoryHolder.GetComponent<Player>();
        // Player player = GetComponent<Player>();
        player.inventory.Add(this);
        collectableItem.enabled = false;
    }
}

public enum CollectableType {
        NONE, WALLET, CAR_KEYS
}
