using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class examineItem : MonoBehaviour
{
    public SlotsUI slotItem;
    public TextMeshProUGUI descript;

    public void DescribeItem()
    {
        if(slotItem.type == CollectableType.WALLET)
        {
            descript.text = "This is a wallet.";
        }
    }
    
}
