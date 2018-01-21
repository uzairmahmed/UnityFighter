using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyHealth : UzairBaseHealth {
    public GameObject energySphere;
    CapsuleCollider capsuleCollider;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rg = GetComponent<Rigidbody>();
	}

    private void Update(){ }

    protected override void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;

        Instantiate(energySphere, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);

        capsuleCollider.isTrigger = true;

    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        rg.AddExplosionForce(knockBack, hitPoint, 10);
    }

    
}
