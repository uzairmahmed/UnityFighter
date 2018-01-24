using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Pickup item that the zombie drops.
 **/

public class UzairOrbProp : MonoBehaviour { 
    //The player and its health
    GameObject player;
    UzairPlayerHealth playerHealth;

    //Trigger
    SphereCollider sc;

    //How much energy is given back
    public float energyGiven = 10;

    // Use this for initialization
    void Start () {
        //gets the only object with the player tag 
        //and then stores its health info (like apple)
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<UzairPlayerHealth>();

        //gets the collider compnenet
        sc = GetComponent<SphereCollider>();
    }
 
    private void OnTriggerEnter(Collider other)
    {
        //When something touches it, check if its THE player
        if (other.gameObject == player)
        {
            //add energy, set orbs remaining energy to zero
            playerHealth.currentEnergy += energyGiven;
            energyGiven = 0;

            //Destroys itself
            Destroy(gameObject);
        }
    }
}
