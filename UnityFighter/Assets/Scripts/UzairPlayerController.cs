using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairPlayerController : MonoBehaviour {

    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Turning(h);
        Animating(v);
    }

    void Turning(float h)
    {
        
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up * speed);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(Vector3.up * -speed);
        }
    }

    void Animating(float v)
    {
        bool walking = (v != 0f);
        anim.SetBool("Idle", !walking);
        anim.SetBool("Moving", walking);
        anim.SetInteger("MoveSpeed", 1);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("MoveSpeed", 2);
        }
    }
}
