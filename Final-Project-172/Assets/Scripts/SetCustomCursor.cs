using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCustomCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D hoverCursor;
    [SerializeField]
    private Vector2 hotSpot = Vector2.zero;
    [SerializeField]
    private GameObject cursorText;
    [SerializeField]
    private bool triggerActive;
    [SerializeField]
    private string textName;



    public void SetCursor()
    {
        //Debug.Log("mose entr");
        Cursor.SetCursor(hoverCursor, hotSpot, CursorMode.Auto);
        cursorText.GetComponent<FollowMouse>().setActive = true;
        cursorText.GetComponent<FollowMouse>().triggerName = textName;
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
        cursorText.GetComponent<FollowMouse>().setActive = false;
    }
}
