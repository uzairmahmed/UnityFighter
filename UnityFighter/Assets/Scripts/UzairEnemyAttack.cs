using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyAttack : MonoBehaviour {

    public float attackInterval = 1.5f;
    public int attackDamage = 5;

    Animator anim;
    GameObject player;
    UzairPlayerHealth playerHealth;
    UzairEnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<UzairPlayerHealth>();
        enemyHealth = GetComponent<UzairEnemyHealth>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= attackInterval && playerInRange && enemyHealth.currentHealth>0)
        {
            Attack();
        }
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
	}

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("Attack");
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
}
