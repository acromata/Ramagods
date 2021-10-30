/* I have wrote so much different things on 1 code. Why did I do this? */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float HorizontalMove;
    private float currentSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    private Rigidbody2D rb;

    bool jump = false;
    bool crouch = false;
    bool sprint = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump")) // Jump
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch")) // Crouch
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


        if(Input.GetKeyDown(KeyCode.LeftShift)) // Sprint
        {
            sprint = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = false;
        }

    }   
        
    void FixedUpdate()
    {

        // Move
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
        
         // Sprint
        if(sprint == true)
        {
            currentSpeed = runSpeed;
        }
        else if(sprint == false)
        {
            currentSpeed = walkSpeed;
        }

    }
}