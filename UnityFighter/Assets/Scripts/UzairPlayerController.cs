using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UzairPlayerController : MonoBehaviour {

    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;

    bool isGrounded = true;

    float h;
    float v;
    float f;
    float ff;
    float j;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        f = Input.GetAxisRaw("Fire1");
        ff = Input.GetAxisRaw("Fire2");
        j = Input.GetAxisRaw("Jump");

        
        Moving();
        Turning();
        FlightSequence();
        Jumping();
        Attack();

    }

    void Moving()
    {
        bool walking = (v != 0f);
        anim.SetBool("Idle", !walking);
        anim.SetBool("Moving", walking);
        anim.SetInteger("Speed", -1);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("Speed", 1);
        }
    }

    void Turning()
    {
        if (h > 0)
            transform.Rotate(Vector3.up * speed);
        else if (h < 0)
            transform.Rotate(Vector3.up * -speed);
    }

    void Jumping()
    {
        if (j != 0)
        {
            playerRigidBody.AddForce(new Vector3(0,50));
            anim.SetTrigger("Jump");
        }
    }

    void FlightSequence()
    {
        anim.SetBool("OnGround", checkIfGrounded());
    }

    void Attack()
    {
        if (f != 0)
        {
            anim.SetTrigger("Attack");
        }
    }

    bool checkIfGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.5f);
    }
}