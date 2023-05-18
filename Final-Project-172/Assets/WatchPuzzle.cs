using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WatchPuzzle : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private RectTransform hourHand;

    [SerializeField]
    private RectTransform minuteHand;

    [SerializeField]
    private int targetHour = 4;
    [SerializeField]
    private int targetMinute = 37;

    [SerializeField]
    private float degreeRange = 15;

    private float prevAngle;


    public void PointerDownHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        position = canvas.transform.TransformPoint(position);
        Vector2 local = position - new Vector2(transform.position.x, transform.position.y);

        prevAngle = Mathf.Atan2(local.y, local.x) * 180 / Mathf.PI;
    }

    public void DragHandler(BaseEventData data)
    {

        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        position = canvas.transform.TransformPoint(position);
        Vector2 local = position - new Vector2(transform.position.x, transform.position.y);
        float newAngle = Mathf.Atan2(local.y, local.x) * 180 / Mathf.PI; ;
        

        float delta = Mathf.DeltaAngle(prevAngle, newAngle);
        minuteHand.Rotate(new Vector3(0, 0, delta));
        float hourDelta = delta / 12;
        hourHand.Rotate(new Vector3(0, 0, hourDelta));
        prevAngle = newAngle;
    }

    public void PointerUpHandler(BaseEventData data)
    {

        float minuteAngle = 360 - minuteHand.rotation.eulerAngles.z;
        float hourAngle = 360 - hourHand.rotation.eulerAngles.z;
        Debug.Log(minuteAngle);
        Debug.Log(hourAngle);

        float targetMinAngle = Mathf.LerpAngle(0, 360, targetMinute / 60);
        float targetHrAngle = Mathf.LerpAngle(0, 360, targetHour / 12) + Mathf.LerpAngle(0, 30, targetMinute / 60);

        if (minuteAngle > targetMinAngle + degreeRange / 2 && minuteAngle < targetMinAngle - degreeRange / 2)
        {
            if (hourAngle > targetHrAngle + degreeRange / 2 && hourAngle < targetHrAngle - degreeRange / 2)
            {
                Debug.Log("Correct!");
            }
        }

    }
}
