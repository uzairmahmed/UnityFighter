using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyHealth : UzairBaseHealth {
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();
        spotLight = GetComponent<Light>();

        capsuleCollider = GetComponent<CapsuleCollider>();
        rg = GetComponent<Rigidbody>();
	}

    private void Update(){ }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Weapon")
        //{
        //    TakeDamage(other.GetComponent<UzairSwordProp>().getDamage(),
        //        other.transform.position,
        //        other.GetComponent<UzairSwordProp>().getDamage());
        //}
    }

    protected override void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;

        capsuleCollider.isTrigger = true;
    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        rg.AddExplosionForce(knockBack, hitPoint, 10);
    }

    
}
