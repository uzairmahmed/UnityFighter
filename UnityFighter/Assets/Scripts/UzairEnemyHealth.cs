using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyHealth : UzairBaseHealth {
    public GameObject energySphere;
    public UzairGameManager gmanager;
    CapsuleCollider capsuleCollider;

    public AudioSource playerAudio;


    protected override void Start() { 
        ucp = GetComponent<UzairCharacterProp>();
        startingHealth = ucp.startingHealth;
        currentHealth = startingHealth;

        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        gmanager = GetComponentInParent<UzairGameManager>();

        gmanager.ZombieArray.Add(gameObject);
	}

    protected override void Update()
    {
        isHit = false;
    }

    protected override void Death()
    {
        playerAudio.Play();

        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;
        
        capsuleCollider.isTrigger = true;

        Instantiate(energySphere, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        gmanager.ZombieArray.Remove(gameObject);
        Destroy(gameObject, 1);
    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        rg.AddExplosionForce(knockBack, hitPoint, 10);
    }

    
}
