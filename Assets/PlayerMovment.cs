using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;


    public float runSpeed = 40f;
    float horizontalMove = 0f;


    bool jump = false;
    bool crouch = false;
  

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        // Conditional for jumping
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        // Conditionnal for crouching
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Managing the state of isJumping when the Player touch the ground 
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    // managing the state of the crouch
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    // Setting the movment
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch , jump);
        jump = false;

    }
}
