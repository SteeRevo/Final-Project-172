using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

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
    private int targetMinute = 35;

    // Range in positive and negative the minute had can be from the target
    [SerializeField]
    private float minRange = 3;

    [SerializeField] private UnityEvent onSolved;

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
        UnitTests();
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

        float minute = angleToMinute(360 - minuteHand.rotation.eulerAngles.z);
        float hour = angleToHour(360 - hourHand.rotation.eulerAngles.z);
        Debug.Log(minute);
        Debug.Log(hour);

        if (hour >= targetHour && hour < targetHour + 1)
        {
            if (minute > targetMinute - minRange && minute < targetMinute + minRange)
            {
                onSolved.Invoke();
                Debug.Log("You Did It!");
            }
        }
    }

    // convert angle of hour hand (in degrees between 0 and 360) to an hour
    private float angleToHour(float angleHr)
    {
        float a = angleHr % 360;
        // idk if this is a cheap hack but its how im doin this
        if (a < 30)
        {
            return Mathf.Lerp(12, 13, a / 30);
        } else
        {
            a = a - 30;
            return Mathf.Lerp(1, 12, a / 330);
        }
    }

    private float angleToMinute(float angleMin)
    {
        float a = angleMin = angleMin % 360;
        return Mathf.Lerp(0, 60, a / 360);
    }

    private void UnitTests()
    {
        // Hour tests
        Debug.Assert(angleToHour(0) == 12);

        Debug.Assert(Mathf.Approximately(angleToHour(18), 12.6f));

        Debug.Assert(angleToHour(30) == 1);

        Debug.Assert(angleToHour(90) == 3);

        Debug.Assert(angleToHour(270) == 9);

        Debug.Assert(angleToHour(360) == 12);

        // Minute Tests

        Debug.Assert(angleToMinute(0) == 0);

        Debug.Assert(angleToMinute(90) == 15);

        // 17 min
        Debug.Assert(angleToMinute(102) == 17, "angleToMinute(102) == 17");

        Debug.Assert(angleToMinute(180) == 30);

        Debug.Assert(angleToMinute(360) == 0);


    }
}
