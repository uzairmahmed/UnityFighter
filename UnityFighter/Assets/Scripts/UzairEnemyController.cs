using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairEnemyController : MonoBehaviour {
    public float fl;
    public float f1;

    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    Animator anim;
    SphereCollider sc; 

    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        sc = GetComponent<SphereCollider>();

    }
	
	// Update is called once per frame
	void Update () {
        fl = nav.remainingDistance;
        f1 = sc.radius;
        nav.SetDestination(player.position);
        transform.LookAt(player);
        anim.SetBool("Moving", true);
    }
}
