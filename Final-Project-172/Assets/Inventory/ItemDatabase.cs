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
    public Sprite icon;

    // public GameObject inventoryPanel;
    public Player player;
    public List<SlotsUI> slots = new List<SlotsUI>();

    public List<CollectableType> storageList = new List<CollectableType>();

    void Awake() {

        DontDestroyOnLoad(this.gameObject);
        Debug.Log(player.inventory.slots.Count);
        for (int i = 0; i < storageList.Count; i++) {
            Collectable item = new Collectable();
            item.type = storageList[i];
            item.icon = icon;
            inventory.Add(item);

        }
        
        // if (slots.Count == player.inventory.slots.Count) {
        //     for (int i = 0; i < slots.Count; i++) {
        //         print(slots[i]);
                // if (player.inventory.slots[i].type != CollectableType.NONE) {
                //     slots[i].SetItem(player.inventory.slots[i]);
                // } else {
                //     slots[i].SetEmpty();
                // } 
        //     }
        // }

        // inventory = new Inventory(2);

        // Collectable item = new Collectable();
        // item.type = CollectableType.WALLET;
        // item.icon = icon;
        // inventory.Add(item);
    }

    // void Start() {
    //     storageList = new List<CollectableType>();
    // }
    // void Update() {
    //     Debug.Log(storageList.Count);
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


