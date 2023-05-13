using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCustomCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D hoverCursor;
    [SerializeField]
    private Vector2 hotSpot = Vector2.zero;

    public void SetCursor()
    {
        //Debug.Log("mose entr");
        Cursor.SetCursor(hoverCursor, hotSpot, CursorMode.Auto);
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }
}
