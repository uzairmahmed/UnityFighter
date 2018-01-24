using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * Player Health Class - Extends from the Base Health
 * What's Unique in this?
 *  >   Adds a XP (or energy) value.
 *  >   Health Regeneration
 *  >   Death method to go to heaven.
 **/

public class UzairPlayerHealth : UzairBaseHealth {

    //AudioClip for when Player gets hit
    public AudioSource hitAudio;

    //The heaven GameObject
    public GameObject heaven;

    //UI Slider for health
    public Slider healthSlider;
    //Max health regen per second.
    int maxRegenPS = 10;    
    
    //UI color for hits, with flash speed
    public Image damageImage;
    public float flashSpeed = 10f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //UI Slider for Energy
    public Slider energySlider;
    //Starting and current energy
    float startingEnergy = 100;
    public float currentEnergy;
    //Energy loss rate over time
    int currentLossRate;
    int normalLossRate = 2;

    //Runs Once
    protected override void Start()
    {
        //Gets the rigidbody, animator and animation 
        //controller and character property
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movement = GetComponent<UzairPlayerController>();
        ucp = GetComponent<UzairCharacterProp>();
        
        //Sets current and starting health to that of the property
        startingHealth = ucp.startingHealth;
        currentHealth = startingHealth;

        //Sets current energy to starting energy
        currentEnergy = startingEnergy;
    }

    //Update is called once per frame
    protected override void Update()
    {
        //Runs managers for respective functions
        healthManager(); 
        energyManager();
    }

    //manages the UI flash and updates
    void healthManager()
    {
        //flash screen with red if hit
        if (isHit)
        {
            damageImage.color = flashColour;
        }
        //otherwise gradually move from the current color to transparent
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //its not being hit anymore
        isHit = false;

        //cap the health to its max
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }

        //Regen health over time
        currentHealth += (currentEnergy / 100) * maxRegenPS * Time.deltaTime;

        //update slider
        healthSlider.value = currentHealth;
    }

    //Manages the loss rate based on activity, along with updating UI
    void energyManager()
    {
        //If the controller is...
        //Jumping, then set loss rate to 4
        if (movement.jump)
        {
            currentLossRate = normalLossRate * 4;
        }
        //Attacking, then set loss rate to 3
        else if (movement.attacking)
        {
            currentLossRate = normalLossRate * 3;
        }
        //Running, then set loss rate to 2
        else if (movement.run)
        {
            currentLossRate = normalLossRate * 2;
        }
        //Walking, then set loss rate to 1
        else if (movement.walk)
        {
            currentLossRate = normalLossRate * 1;
        }
        //Otherwise, set loss rate to 0
        else
        {
            currentLossRate = normalLossRate * 0;
        }

        //cap the energy to its max
        if (currentEnergy >= startingEnergy)
        {
            currentEnergy = startingEnergy;
        }

        //Lose energy over time
        currentEnergy -= currentLossRate * Time.deltaTime;

        //update slider
        energySlider.value = currentEnergy;
    }

    //Death
    protected override void Death()
    {
        //Set is dead to true, animate the death, disable movement
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;

        //Send player to heaven
        transform.position = heaven.transform.position;
        transform.rotation = Quaternion.identity;

        

        //set UI background to red
        damageImage.color = Color.red;
    }

    //When the player gets hit
    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        //play the hit sound
        hitAudio.Play();
    }
}