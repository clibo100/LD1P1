using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeClusterRotation : MonoBehaviour {
    public float upLimit = 2.5f;
    public float downLimit = 1.0f;
    public float leftLimit = 1.0f;
    public float rightLimit = 2.5f;
    public float speed = 2.0f;
    private int verticaldirection = 1;
    private int horizontaldirection = 1;
    private Vector3 movement;

    void Update()
    {
        if (transform.position.y > upLimit)
        {
            verticaldirection = -1;
        }
        else if (transform.position.y < downLimit)
        {
            verticaldirection = 1;
        }
        movement = Vector3.up * verticaldirection * speed * Time.deltaTime;
        transform.Translate(movement);

        if (transform.position.x > rightLimit)
        {
            horizontaldirection = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            horizontaldirection = 1;
        }
        movement = Vector3.right * horizontaldirection * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
