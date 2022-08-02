using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(joystick.joystickVector.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVector.x * speed, joystick.joystickVector.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
