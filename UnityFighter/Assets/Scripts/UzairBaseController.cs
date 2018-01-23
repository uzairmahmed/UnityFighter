using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairBaseController : MonoBehaviour {
    protected Animator anim;

    public bool attacking;
    public bool walk;
    public bool run;
    public bool jump;

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
}
