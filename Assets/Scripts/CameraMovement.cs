using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minX, minY, maxX, maxY;
    private Transform player;
    private Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPosition = transform.position;
        tempPosition.x = transform.position.x;
        tempPosition.y = transform.position.y;

        if (tempPosition.x < minX)
        {
            tempPosition.x = minX;
        }
        if (tempPosition.x > maxX)
        {
            tempPosition.x = maxX;
        }

        transform.position = tempPosition;
    }
}
