using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player Controller Class - Inherits from the Base Controller Class
 * What's Unique in this?
 *  >   Uses the Input Axis for controls
**/

public class UzairPlayerController : UzairBaseController
{
    //Player rigidbody
    Rigidbody rg;

    //Sound to play on attack
    public AudioSource attackSound;

    //direction of movement
    Vector3 movement;

    //animation speed
    public float speed = 6f;

    //Axis stored values
    float h;
    float v;
    float f;
    float ff;
    float j;

    //runs once
    protected override void Start()
    {
        //gets rigidbody and animator components
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    protected override void Update()
    {
        //Gets and updates each input per axis
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        f = Input.GetAxisRaw("Fire1");
        j = Input.GetAxisRaw("Jump");
        
        //explained below
        Move();
        Attack();
        AttackAnimManager();
    }

    //Checks for moving, running, turning or jumping
    void Move()
    {
        //sets the animation booleans to match that of walk
        walk = (v != 0f);
        anim.SetBool("Idle", !walk); 
        anim.SetBool("Moving", walk);

        
        //if shift is held down, set the speed to run speed and make run true
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            anim.SetInteger("Speed", 1);
        }
        //otherwise, set run to false and set speed to normal walking speed
        else
        {
            run = false;
            anim.SetInteger("Speed", -1);
        }

        //turn to whatever side its aiming
        if (h > 0)
            transform.Rotate(Vector3.up * speed);
        else if (h < 0)
            transform.Rotate(Vector3.up * -speed);

        //set jump to true and add a force upwards
        if (j != 0)
        {
            jump = true;
            rg.AddForce(new Vector3(0, 100000));
        }
        else
        {
            jump = false;
        }
    }

    //Attakc
    protected override void Attack()
    {
        //if the fire button is pressed
        if (f != 0)
        {
            //set moving to false, activate the trigger, and play the hit sound
            anim.SetBool("Moving", false);
            anim.SetTrigger("Attack");
            attackSound.Play();
        }
    }
}