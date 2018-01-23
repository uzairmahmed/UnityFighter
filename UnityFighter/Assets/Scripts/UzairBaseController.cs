using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairBaseController : MonoBehaviour {
    protected Animator anim;
    public bool attacking;

	// Use this for initialization
	protected virtual void Start () {
        return;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        return;
	}

    protected virtual void Attack()
    {
        return;
    }

    protected virtual void AttackAnimManager()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }

    public bool checkIfGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.5f);
    }

    
}
