using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour {

    public float upLimit = 2.5f;
    public float downLimit = 1.0f;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;

    void Update()
    {
        if (transform.position.y > upLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < downLimit)
        {
            direction = 1;
        }
        movement = Vector3.up * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    // Use this for initialization
    void Start()
    {

    }
}
