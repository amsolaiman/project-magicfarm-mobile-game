using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBackground;
    public Vector2 joystickVector;
    private Vector2 joystickTouchPosition;
    private Vector2 joystickOriginalPosition;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPosition = joystickBackground.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBackground.transform.position = Input.mousePosition;
        joystickTouchPosition = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVector = (dragPos - joystickTouchPosition).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPosition);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPosition + joystickVector * joystickDist;
        }

        else
        {
            joystick.transform.position = joystickTouchPosition + joystickVector * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVector = Vector2.zero;
        joystick.transform.position = joystickOriginalPosition;
        joystickBackground.transform.position = joystickOriginalPosition;
    }
}
