using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSingleton : MonoBehaviour
{
    public static ItemSingleton instance { get; private set; }

    public List<Collectable> storageList = new List<Collectable>();

    private void Awake() {

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else {
            Destroy(this);

        }
    }
}
