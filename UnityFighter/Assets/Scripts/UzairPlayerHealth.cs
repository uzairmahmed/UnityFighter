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

    int maxRegenPS = 10;
    int energyLossRate = 4;

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
        healthManager(); 
        energyManager();
    }

    void energyManager()
    {
        if (currentEnergy >= startingEnergy)
        {
            currentEnergy = startingEnergy;
        }
        currentEnergy -= energyLossRate * Time.deltaTime;
        energySlider.value = currentEnergy;
    }

    void healthManager()
    {
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }
        currentHealth += (currentEnergy / 100) * maxRegenPS * Time.deltaTime;
        healthSlider.value = currentHealth;
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
        playerAudio.Play();
    }
}