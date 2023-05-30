using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberSlot : MonoBehaviour, IDropHandler
{
    public bool occupied = false;

    public int ID;


    private bool checkID(int n)
    {
        return ID == n;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if(checkID(eventData.pointerDrag.GetComponent<Number>().ID))
            {
                eventData.pointerDrag.transform.position = transform.position;
                occupied = true;
            
            }
            
        }
    }
}
