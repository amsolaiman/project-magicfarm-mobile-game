using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraAction : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float minZoom, maxZoom;
    private Camera camera;
    private Vector3 touchPosition;
    private bool moveAllowed;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                if(EventSystem.current.IsPointerOverGameObject(touchOne.fingerId)
                    || EventSystem.current.IsPointerOverGameObject(touchZero.fingerId))
                {
                    return;
                }

                Vector2 touchZeroLastPosition = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOneLastPosition = touchOne.position - touchOne.deltaPosition;
                float touchDistance = (touchZeroLastPosition - touchOneLastPosition).magnitude;
                float touchCurrentDistance = (touchZero.position - touchOne.position).magnitude;
                float difference = touchCurrentDistance - touchDistance;

                Zoom(difference * 0.01f);
            }
            else
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                        {
                            moveAllowed = false;
                        }
                        else
                        {
                            moveAllowed = true;
                        }
                        touchPosition = camera.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Moved:
                        if(moveAllowed)
                        {
                            Vector3 direction = touchPosition - camera.ScreenToWorldPoint(touch.position);
                            camera.transform.position += direction;

                            transform.position = new Vector3
                                (
                                    Mathf.Clamp(transform.position.x, minX, maxX),
                                    Mathf.Clamp(transform.position.y, minY, maxY),
                                    transform.position.z
                                );
                        }
                        break;
                }
            }
        }
    }

    private void Zoom(float increment)
    {
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - increment, minZoom, maxZoom);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(new Vector3
    //        (
    //            (maxX - Mathf.Abs(minX) / 2),
    //            (maxY - Mathf.Abs(minY) / 2)
    //        ),
    //            new Vector3(maxX - minX, maxY - minY)
    //        );
    //}
}
