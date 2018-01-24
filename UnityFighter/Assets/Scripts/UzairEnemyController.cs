using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * Zombie Controller Class - Inherits from the Base Controller Class
 * What's Unique in this?
 *  >   Uses the NavMesh Agent for AI
**/

public class UzairEnemyController : UzairBaseController
{
    //the player gameobject
    GameObject player;

    //a sphere collider for the zombie's reach
    SphereCollider sc;

    //a navmesh agent to anvigate around the map
    NavMeshAgent nav;

    //enemy and player's health info
    UzairEnemyHealth enemyHealth;
    UzairPlayerHealth playerHealth;

    //the players animation and character properties
    UzairPlayerController playerController;
    UzairCharacterProp myProps;

    //attack damage, interval and timer to space attacks out evenly
    int attackDamage;
    float attackInterval;
    float timer;


    //the animators speed
    float speed;
    
    //is it within my reach?
    bool playerInRange;

    // Use this for initialization
    protected override void Start()
    {
        //gets the animator and collider components (yay i speeled it right!)
        anim = GetComponent<Animator>();
        sc = GetComponent<SphereCollider>();

        //gets own properties, navmesh and health info
        myProps = GetComponent<UzairCharacterProp>();
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<UzairEnemyHealth>();


        //gets the only Player object and store its health and animator info
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<UzairPlayerHealth>();
        playerController = player.GetComponent<UzairPlayerController>();

        //sets the local props to the Set zombie props
        attackInterval = myProps.attackInterval;
        attackDamage = myProps.attackDamage;
        speed = myProps.speed;
        transform.localScale += new Vector3(myProps.scale, myProps.scale, myProps.scale);

        //sets animator and navmesh speed
        anim.speed = speed;
        nav.speed = speed*3;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //begins a timer
        timer += Time.deltaTime;

        //sets the target to the player. (it was THAT easy)
        nav.SetDestination(player.transform.position);
        transform.LookAt(player.transform);

        //sets animator moving to true
        anim.SetBool("Moving", true);

        //attacks if in range, timer is okay, and is alive
        if (timer >= attackInterval && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        //checks if zombie is currently attacking
        AttackAnimManager();

    }

    //if something collides with it
    private void OnTriggerEnter(Collider other)
    {
        //if its the target, set inrange to true
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
        //if its the sword, and the player is attacking, take damage.
        else if (other.gameObject.tag == "Weapon" && playerController.attacking)
        {
            enemyHealth.TakeDamage(other.GetComponent<UzairSwordProp>().getDamage(),
                other.transform.position,
                other.GetComponent<UzairSwordProp>().getDamage());
        }
    }

    //if something leaves collision
    private void OnTriggerExit(Collider other)
    {
        //if its the player set inrange to false
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    //attack
    protected override void Attack()
    {
        //reset the attack timer
        timer = 0f;
        //if the player is still alive, 
        if (playerHealth.currentHealth >= 0)
        {
            ////animate the attack
            anim.SetTrigger("Attack");

            //ramove healths
            playerHealth.TakeDamage(attackDamage, transform.position, 0);
        }
    }
}
