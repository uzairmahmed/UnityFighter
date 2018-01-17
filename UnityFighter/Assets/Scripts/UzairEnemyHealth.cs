using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    Animator anim;
    CapsuleCollider capsuleCollider;
    UzairEnemyController enemyMovement;
    Rigidbody rg;
    bool isDead;
    bool isSinking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rg = GetComponent<Rigidbody>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        rg.AddExplosionForce(1000, hitPoint, 10);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Die");
        enemyMovement.enabled = false;
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            TakeDamage(other.GetComponent<UzairSwordProp>().getDamage(), other.transform.position);
        }
    }
}
