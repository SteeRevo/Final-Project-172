using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{
    // public CollectableType type;
    
    // public Sprite icon;
    // public GameObject InventoryHolder;
    // private Player player;
    // private Image collectableItem;

    // private Collectable collectableItemScript;
    // Start is called before the first frame update
    private Inventory inventory; 
    // public Sprite icon;

    // public GameObject inventoryPanel;
    public Player player;

    public List<Collectable> storageList = new List<Collectable>();

    void Start() {

        DontDestroyOnLoad(this.gameObject);
        Debug.Log("hello");
        Debug.Log(storageList.Count);
        for (int i = 0; i < storageList.Count; i++) {
            Collectable item = new Collectable();
            item.type = storageList[i].type;
            Debug.Log(item.type);
            item.icon = storageList[i].icon;
            Debug.Log(item.icon);
            player.inventory.Add(item);

        }

    }




    // void Start() {
    //     Collectable temp = new Collectable();
    //         temp.type = CollectableType.WALLET;
    //         Debug.Log(temp.type);
    //         temp.icon = icon;
    //         Debug.Log(temp.icon);
    //         storageList.Add(temp);
    //         player.inventory.Add(temp);
    //         Debug.Log(player.inventory.slots.Count);
    //     // storageList = new List<CollectableType>();
    // }


    // void Start() {
    //     storageList = new List<string>();
    //     for (int i = 0; i < player.inventory.slots.Count; i++) {
    //         storageList.Add(player.inventory.slots[i].type);
    //     }
    // }


    // void Update() {
    //     for (int i = 0; i < player.inventory.slots.Count; i++) {
    //         Debug.Log(player.inventory.slots[i].type);
    //     }
    // }

    // iterate through the inventory
    // save the values somehow
    // void Start()
    // {
        // inventory = new Inventory(2);
        // // Slot slot = inventory.slots[0];
        // Collectable item = new Collectable();
        // item.type = CollectableType.WALLET;
        // item.icon = LoadSpriteFromPNG("./Assets/Art/wallet_pixel");;
        // inventory.Add(item);


        // collectableItemScript = GetComponent<Collectable>();

        // type = 1;
        // collectableItem = Resources.Load<Image>.sprite("wallet_pixel");;
        // type = CollectableType.WALLET;
        // Sprite sprite = LoadSpriteFromPNG("./Assets/Art/wallet_pixel");
        // collectableItem.sprite = sprite;
        // icon = LoadSpriteFromPNG("./Assets/Art/wallet_pixel");
        // player = InventoryHolder.GetComponent<Player>();
        // collectableItemScript.CollectItem
        // player.inventory.Add();





}

    // // Helper method to load a Sprite from a PNG file
    // private Sprite LoadSpriteFromPNG(string filePath)
    // {
    //     // Load the PNG file as a Texture2D
    //     Texture2D texture = Resources.Load<Texture2D>(filePath);

    //     if (texture != null)
    //     {
    //         // Create a Sprite from the loaded Texture2D
    //         Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    //         return sprite;
    //     }

    //     return null;
    // }


