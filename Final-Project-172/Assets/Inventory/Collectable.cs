using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private ItemDatabase itemDatabaseScript;

    public CollectableType type;
    
    public Sprite icon;
    public GameObject InventoryHolder;
    // public GameObject ItemDatabaseManager;
    private Player player;
    private Image collectableItem;

    void Awake() {
    }

    void Start() {
        // itemDatabaseScript = InventoryHolder.GetComponent<ItemDatabase>();

    }

    // void Update() {
    //     Debug.Log(itemDatabaseScript.storageList);
    // }

    public void CollectItem() {
        Debug.Log("collected!");
        // Player player = GetComponent<Player>();
        // player.inventory.Add(this);
        player = InventoryHolder.GetComponent<Player>();
        // player = ItemDatabaseManager.GetComponent<Player>();
        collectableItem = this.gameObject.GetComponent<Image>();
        // Player player = GetComponent<Player>();
        player.inventory.Add(this);
        collectableItem.enabled = false;
        ItemSingleton.instance.storageList.Add(this);
        // itemDatabaseScript.storageList.Add(this);
        Debug.Log( ItemSingleton.instance.storageList.Count);
    }
}

public enum CollectableType {
        NONE, WALLET, CAR_KEYS
}
