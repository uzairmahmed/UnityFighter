using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UzairPlayerController : MonoBehaviour {

    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;

    float h;
    float v;
    float f;
    float ff;
    float j;
    float mx;
    float my;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        f = Input.GetAxisRaw("Fire1");
        ff = Input.GetAxisRaw("Fire2");
        j = Input.GetAxisRaw("Jump");
        mx = Input.GetAxisRaw("Mouse X");
        my = Input.GetAxisRaw("Mouse Y");

        
        Moving();
        Turning();
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
        if (mx > 0)
            transform.Rotate(Vector3.up * speed);
        else if (mx < 0)
            transform.Rotate(Vector3.up * -speed);
    }

    void Jumping()
    {
        if (j != 0)
        {
            //anim.SetTrigger("Jump");
            playerRigidBody.AddForce(new Vector3(0, 100));
        }
    }

    void Attack()
    {
        if (f != 0)
        {
            anim.SetTrigger("Attack");
        }
    }


}
