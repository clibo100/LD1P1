﻿using UnityEngine;

using System.Collections;



public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float sprintSpeed = 8f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    public bool isJumping = false;
    public bool canDoubleJump = false;
    public int jumpCount = 0;

    [HideInInspector]
    public bool isFacingLeft = false;
    public bool isMoving = false;
    public bool isSprinting = false;
    public double previousX;
    public double currentX;

    /// SOUNDS
    private AudioSource source;
    public AudioClip jumpSound;
    public AudioClip spawnSound;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(spawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        previousX = System.Math.Round(this.gameObject.transform.position.x, 2);
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isSprinting = false;
        }



        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            isJumping = false;
            DBMovement();

            if (isSprinting)
            {
                moveDirection *= 0;// sprintSpeed;
            }

            if (!isSprinting)
            {
                moveDirection *= 0;// speed;
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (controller.isGrounded)
            {
                moveDirection.y = jumpSpeed;
                isJumping = true;
                source.PlayOneShot(jumpSound);
                jumpCount=1;
            }
            else if (canDoubleJump)
            {
                if (jumpCount<2)
                {
                    jumpCount=2;
                    moveDirection.y = jumpSpeed;
                    isJumping = true;
                    source.PlayOneShot(jumpSound);
                }
                else
                {
                    jumpCount = 0;
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.x = Input.GetAxis("Horizontal") * ((isSprinting) ? sprintSpeed : speed);
        DBMovement();
        controller.Move(moveDirection * Time.deltaTime);
        currentX = System.Math.Round(this.gameObject.transform.position.x, 2);

        //Check to see if we are currently moving... this is needed for animation purposes...
        if (previousX != currentX)
        {
            isMoving = true;
        }

        else if (previousX == currentX)
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "MovingPlatform")
        {
            transform.parent = other.transform.parent;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void DBMovement()
    {
        if (moveDirection.x > 0)
        {
            //Debug.Log ("I moved right!");
            isFacingLeft = false;
        }
        else if (moveDirection.x < 0)
        {
            //Debug.Log ("I moved left!");
            isFacingLeft = true;
        }

    }

}