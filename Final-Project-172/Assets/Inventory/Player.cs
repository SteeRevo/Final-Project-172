using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Inventory inventory;
   void Awake() {
      inventory = new Inventory(2);
      // inventory = ItemSingleton.instance.inventory;
   }
}

// [System.Serializable]
// public struct InventorySaveData {
//    public Inventory inventory;

//    public InventorySaveData(Inventory _inv) {
//       invSystem = _inv;
//    }
// }