using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    public CollectableType type;
    // public Image collectableItem;

    public void CollectItem() {
        Debug.Log("collected!");
        Player player = GetComponent<Player>();
        player.inventory.Add(type);
        // collectableItem.enabled = false;
    }
}

public enum CollectableType {
        NONE, WALLET
}
