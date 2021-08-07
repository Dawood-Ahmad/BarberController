using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCameraPad : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Vector2 previousPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = Input.mousePosition;
        if (!AxisSaver.dragging)
        {
            if (currentPosition.x > previousPosition.x)
            {
                AxisSaver.xMove = true;
                AxisSaver.xPositive = true;
            }
            else if (currentPosition.x < previousPosition.x)
            {
                AxisSaver.xMove = true;
                AxisSaver.xPositive = false;
            }


            if (currentPosition.y > previousPosition.y)
            {
                AxisSaver.yMove = true;
                AxisSaver.yPositive = true;
            }
            else if (currentPosition.y < previousPosition.y)
            {
                AxisSaver.yMove = true;
                AxisSaver.yPositive = false;
            }
        }
        
        previousPosition = currentPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        previousPosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

}
