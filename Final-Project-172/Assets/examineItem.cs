using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class examineItem : MonoBehaviour
{
    public SlotsUI slotItem;
    public TextMeshProUGUI descript;

    public delegate void checkItem();
    public static event checkItem walletChecked;


    public void DescribeItem()
    {
        if(slotItem.type == CollectableType.WALLET)
        {
            descript.text = "Your wallet. It contains $50, a few credit cards and your ID. Your address is listed as 555 Tulwick Road.";
            walletChecked();
        }
       
    }
    
}
