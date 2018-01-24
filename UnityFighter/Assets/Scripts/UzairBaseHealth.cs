using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Base Health Class
 * Manages the health and damage method for players
 **/

public class UzairBaseHealth : MonoBehaviour {

    //Rigidbody componenet
    protected Rigidbody rg;
    //Animator componenet
    protected Animator anim;
    //animation controller
    protected UzairBaseController movement;
    //character property
    protected UzairCharacterProp ucp;

    //Starting and current health
    protected float startingHealth;
    public float currentHealth;

    //if dead or being attacked atm
    public bool isDead;
    protected bool isHit;

    protected virtual void Start()
    {
        return;
    }

    protected virtual void Update()
    {
        return;
    }

    //Called by OTHER players to subtract health. (zombies have a knowback added)
    public void TakeDamage(int amount, Vector3 hitPoint, int knockback)
    {
        //Run the function unless the player is already dead
        if (isDead)
        {
            return;
        }

        //player is now being attacked
        isHit = true;
        //subtract health
        currentHealth -= amount;
        //start the hit animation for whoever
        anim.SetTrigger("Hit");
        //Run the custom hit method
        HitMethod(hitPoint, knockback);

        //if it wasnt dead before, and now it is, kill it
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }

    protected virtual void Death()
    {
        return;
    }

    protected virtual void HitMethod(Vector3 hitPoint, int knockBack)
    {
        return;
    }


}
