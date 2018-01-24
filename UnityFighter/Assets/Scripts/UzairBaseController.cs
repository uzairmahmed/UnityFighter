using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * manages the Animations for the players
 **/

public class UzairBaseController : MonoBehaviour {
    //the animator
    protected Animator anim;

    //booleans to check what its doing atm
    public bool attacking;
    public bool walk;
    public bool run;
    public bool jump;

    //attacking is true only during the attack ANIMATION
    protected virtual void AttackAnimManager()
    {
        //is the animator running in the "Attack" state atm?
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        { 
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        return;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        return;
    }

    //They have there own special ways of attacking
    protected virtual void Attack()
    {
        return;
    }
}
