using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairPlayerAttack : MonoBehaviour
{

    public float attackInterval = 1.5f;
    public int attackDamage = 5;

    UzairPlayerHealth playerHealth;
    UzairEnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;


    // Use this for initialization
    void Start()
    {
        enemyHealth = GetComponent<UzairEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval && enemyInRange && playerHealth.currentHealth > 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;
        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemyInRange = true;
            enemyHealth = other.GetComponent<UzairEnemyHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemyInRange = false;
            enemyHealth = null;
        }
    }
}
