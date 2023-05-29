using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{

    private Inventory inventory; 

    public Player player;

    // public List<Collectable> storageList = new List<Collectable>();

    void Awake() {

        DontDestroyOnLoad(this.gameObject);

    }

    void Start() {
        Debug.Log("hello");
        Debug.Log(ItemSingleton.instance.storageList.Count);

        for (int i = 0; i < ItemSingleton.instance.storageList.Count; i++) {
            Collectable item = new Collectable();
            item.type = ItemSingleton.instance.storageList[i].type;
            Debug.Log(item.type);
            item.icon = ItemSingleton.instance.storageList[i].icon;
            Debug.Log(item.icon);
            player.inventory.Add(item);

        }
    }
}



