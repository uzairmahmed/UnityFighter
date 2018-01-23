using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UzairPlayerHealth : UzairBaseHealth {
    
    public Slider healthSlider;
    public Image damageImage;

//    public AudioClip deathClip;
    public AudioSource playerAudio;

    public Slider energySlider;

    float startingEnergy = 100;
    public float currentEnergy;

    int energyLossRate = 2;

    // Use this for initialization
    protected override void Start()
    {
        ucp = GetComponent<UzairCharacterProp>();
        startingHealth = ucp.startingHealth;
        currentHealth = startingHealth;

        playerAudio = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();

        currentEnergy = startingEnergy;
    }

    // Update is called once per frame
    protected override void Update()
    {
        isHit = false;
        energyManager();
    }

    void energyManager()
    {
        currentEnergy -= energyLossRate * Time.deltaTime;
        energySlider.value = currentEnergy;
    }

    protected override void Death()
    {
        //playerAudio.clip = deathClip;

        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;
    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        healthSlider.value = currentHealth;
        playerAudio.Play();
    }
}