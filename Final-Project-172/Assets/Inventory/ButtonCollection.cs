using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCollection : MonoBehaviour
{
    public Collectable collectable;
    public CollectableType type;
    
    public Sprite icon;
    public GameObject InventoryHolder;

    private Player player;
    private Image collectableItem;


    public void AutoCollectButton() {
        collectable = this.gameObject.GetComponent<Collectable>();
        player = InventoryHolder.GetComponent<Player>();
        player.inventory.Add(collectable);
    }
}
