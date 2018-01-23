using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UzairPlayerController : UzairBaseController
{

    public float speed = 6f;

    Vector3 movement;
    Rigidbody rg;
    
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
        walk = (v != 0f);
        anim.SetBool("Idle", !walk);
        anim.SetBool("Moving", walk);
        anim.SetInteger("Speed", -1);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            anim.SetInteger("Speed", 1);
        }
        else
        {
            run = false;
        }

        if (h > 0)
            transform.Rotate(Vector3.up * speed);
        else if (h < 0)
            transform.Rotate(Vector3.up * -speed);

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

    protected override void Attack()
    {
        if (f != 0)
        {
            anim.SetBool("Moving", false);
            anim.SetTrigger("Attack");
        }
    }
}