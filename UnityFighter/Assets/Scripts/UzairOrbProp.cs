using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairOrbProp : MonoBehaviour {
    GameObject player;
    UzairPlayerHealth playerHealth;

    SphereCollider sc;

    public float energyGiven = 100;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<UzairPlayerHealth>();

        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.currentEnergy += energyGiven;
            energyGiven = 0;
            Destroy(gameObject, 0.5f);
        }
    }
}
