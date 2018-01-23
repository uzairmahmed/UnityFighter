using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairBaseHealth : MonoBehaviour {

    protected Animator anim;
    protected Rigidbody rg;
    protected UzairBaseController movement;
    protected UzairCharacterProp ucp;

    protected bool isDead;
    protected bool isHit;

    protected float startingHealth;
    public float currentHealth;
    
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

    public void TakeDamage(int amount, Vector3 hitPoint, int knockback)
    {
        if (isDead)
        {
            return;
        }

        isHit = true;
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        HitMethod(hitPoint, knockback);

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
