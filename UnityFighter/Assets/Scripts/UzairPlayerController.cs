using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UzairPlayerController : UzairBaseController
{

    public float speed = 6f;

    Vector3 movement;
    Rigidbody rg;

    bool isGrounded = true;

    float h;
    float v;
    float f;
    float ff;
    float j;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        f = Input.GetAxisRaw("Fire1");
        j = Input.GetAxisRaw("Jump");
        
        Move();
        Attack();
        AttackAnimManager();
    }

    void Move()
    {
        bool walking = (v != 0f);
        anim.SetBool("Idle", !walking);
        anim.SetBool("Moving", walking);
        anim.SetInteger("Speed", -1);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("Speed", 1);
        }

        if (h > 0)
            transform.Rotate(Vector3.up * speed);
        else if (h < 0)
            transform.Rotate(Vector3.up * -speed);

        anim.SetBool("OnGround", checkIfGrounded());

        /*if (j != 0)
        {
            rg.AddForce(new Vector3(0, 500));
            anim.SetTrigger("Jump");
        }*/
    }

    protected override void Attack()
    {
        if (f != 0)
        {
            anim.SetBool("Moving", false);
            anim.SetTrigger("Attack");
        }
    }
}