using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UzairEnemyController : UzairBaseController
{
    GameObject player;
    SphereCollider sc;
    NavMeshAgent nav;

    UzairEnemyHealth enemyHealth;
    UzairPlayerHealth playerHealth;

    UzairPlayerController playerController;
    UzairCharacterProp ucp;

    float attackInterval;
    int attackDamage;

    float speed;

    bool playerInRange;
    float timer;

    // Use this for initialization
    protected override void Start()
    {
        anim = GetComponent<Animator>();
        sc = GetComponent<SphereCollider>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<UzairPlayerHealth>();
        playerController = player.GetComponent<UzairPlayerController>();
        ucp = GetComponent<UzairCharacterProp>();

        attackInterval = ucp.attackInterval;
        attackDamage = ucp.attackDamage;
        speed = ucp.speed;

        enemyHealth = GetComponent<UzairEnemyHealth>();

        anim.speed = speed;

        nav = GetComponent<NavMeshAgent>();
        transform.localScale += new Vector3(ucp.scale, ucp.scale, ucp.scale);
    }

    // Update is called once per frame
    protected override void Update()
    {
        timer += Time.deltaTime;

        nav.SetDestination(player.transform.position);
        transform.LookAt(player.transform);

        anim.SetBool("Moving", true);

        if (timer >= attackInterval && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        AttackAnimManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
        else if (other.gameObject.tag == "Weapon" && playerController.attacking)
        {
            enemyHealth.TakeDamage(other.GetComponent<UzairSwordProp>().getDamage(),
                other.transform.position,
                other.GetComponent<UzairSwordProp>().getDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    protected override void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("Attack");
            playerHealth.TakeDamage(attackDamage, transform.position, 0);
        }
    }
}
