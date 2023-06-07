using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCollection : MonoBehaviour
{
    public Collectable collectable;
    public CollectableType type;
    
    public Sprite icon;
    public GameObject InventoryHolder;

    private Player player;
    private Image collectableItem;

    void Start()
    {
        Debug.Log("AUTO COLLECT DDBODYWALLET");
        collectable = this.gameObject.GetComponent<Collectable>();
        player = InventoryHolder.GetComponent<Player>();
        player.inventory.Add(collectable);
        
    }

}
