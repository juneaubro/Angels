﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3f;
    public GameObject fCam;
    public GameObject fCam_down;
    public GameObject fCam_up;
    public GameObject fCam_left;
    public GameObject fCam_right;
    public GameObject fCam_downright;
    public GameObject fCam_downleft;
    public GameObject fCam_upright;
    public GameObject fCam_upleft;
    public GameObject flashlight;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;
    private Quaternion newRotation;

    const float FACING_RIGHT_DIR = 90f;
    const float FACING_LEFT_DIR = -90f;
    const float FACING_UP_DIR = 180f;
    const float FACING_DOWN_DIR = 0f;
    const float FACING_DOWNRIGHT_DIR = 45f;
    const float FACING_DOWNLEFT_DIR = -45f;
    const float FACING_UPRIGHT_DIR = 135f;
    const float FACING_UPLEFT_DIR = -135f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void LateUpdate()
    {
        PlayerAndFlashlightHandling();
    }

    void FixedUpdate()
    {                                           // normalized fixes moving diagonally. makes speed constant
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); // LOL fixedDeltaTime vs deltaTime?
    }

    void PlayerAndFlashlightHandling()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.1) // right
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_RIGHT_DIR);
            flashlight.transform.position = new Vector3(fCam_right.transform.position.x, fCam_right.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Horizontal") < -0.1) //  left
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_LEFT_DIR);
            flashlight.transform.position = new Vector3(fCam_left.transform.position.x, fCam_left.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") > 0.1) // up
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_UP_DIR);
            flashlight.transform.position = new Vector3(fCam_up.transform.position.x, fCam_up.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") < -0.1) // down
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_DOWN_DIR);
            flashlight.transform.position = new Vector3(fCam_down.transform.position.x, fCam_down.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") < -0.1 && Input.GetAxisRaw("Horizontal") > 0.1) // downright
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_DOWNRIGHT_DIR);
            flashlight.transform.position = new Vector3(fCam_downright.transform.position.x, fCam_downright.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") < -0.1 && Input.GetAxisRaw("Horizontal") < -0.1) // downleft
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_DOWNLEFT_DIR);
            flashlight.transform.position = new Vector3(fCam_downleft.transform.position.x, fCam_downleft.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") > 0.1 && Input.GetAxisRaw("Horizontal") > 0.1) // upright
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_UPRIGHT_DIR);
            flashlight.transform.position = new Vector3(fCam_upright.transform.position.x, fCam_upright.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (Input.GetAxisRaw("Vertical") > 0.1 && Input.GetAxisRaw("Horizontal") < -0.1) // upleft
        {
            newRotation = Quaternion.Euler(fCam.transform.rotation.x, fCam.transform.rotation.y, FACING_UPLEFT_DIR);
            flashlight.transform.position = new Vector3(fCam_upleft.transform.position.x, fCam_upleft.transform.position.y, transform.position.z);
            fCam.transform.rotation = newRotation;
        }
        if (flashlight.transform.rotation != fCam.transform.rotation)
        {
            flashlight.transform.rotation = newRotation;
        }
    }
}
