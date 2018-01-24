using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Zombie Health Class - Inherts from the Base Health
 * What's Unique in this?
 *  >   Adds a dropped item component
 *  >   Death method just kills it
 *  >   Uses colliders for triggers
 **/

public class UzairEnemyHealth : UzairBaseHealth {

    //Audio clip to play at death
    public AudioSource playerAudio;

    //Game manager
    public UzairGameManager gmanager;
    
    //Pickup item that drops after death
    public GameObject energySphere;

    //Collider
    CapsuleCollider capsuleCollider;
    
    //runs once
    protected override void Start() {
        //Gets the rigidbody, animator and animation 
        //controller and character property
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movement = GetComponent<UzairBaseController>();
        ucp = GetComponent<UzairCharacterProp>();

        //Sets current and starting health to that of the property
        startingHealth = ucp.startingHealth;
        currentHealth = startingHealth;

        //gets audioclip automagically
        playerAudio = GetComponent<AudioSource>();

        //gets collider componenet
        capsuleCollider = GetComponent<CapsuleCollider>();

        //Gets the gamemanager componenet and adds itself to a array
        gmanager = GetComponentInParent<UzairGameManager>();
        gmanager.ZombieArray.Add(gameObject);
	}

    //Update is called once per frame
    protected override void Update()
    {
        isHit = false;
    }

    protected override void Death()
    {
        //Play the death sound
        playerAudio.Play();

        //Set is dead to true, animate the death, disable movement
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;
        
        //sets itself to a trigger so it doesn't interfere with phisics
        capsuleCollider.isTrigger = true;

        //Instanstiates a new pickup item at its death place
        Instantiate(energySphere, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);

        //Removes itself from the zombie array and destroys itslef
        gmanager.ZombieArray.Remove(gameObject);
        Destroy(gameObject, 1);
    }

    //adds the knockback when hit.
    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        rg.AddExplosionForce(knockBack, hitPoint, 10);
    }

    
}
