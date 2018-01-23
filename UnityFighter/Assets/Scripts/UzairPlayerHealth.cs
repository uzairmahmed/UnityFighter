using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UzairPlayerHealth : UzairBaseHealth {
    
    public Slider healthSlider;
    public Image damageImage;

    public AudioSource playerAudio;

    public Slider energySlider;

    float startingEnergy = 100;
    public float currentEnergy;


    public float flashSpeed = 10f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    int maxRegenPS = 10;

    int currentLossRate;
    int normalLossRate = 2;

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
        healthManager(); 
        energyManager();
    }

    void energyManager()
    {
        if (movement.jump)
        {
            currentLossRate = normalLossRate * 4;
        }
        else if(movement.attacking)
        {
            currentLossRate = normalLossRate * 3;
        }
        else if (movement.run)
        {
            currentLossRate = normalLossRate * 2;
        }
        else if (movement.walk)
        {
            currentLossRate = normalLossRate * 1;
        }
        else
        {
            currentLossRate = normalLossRate * 0;
        }


        if (currentEnergy >= startingEnergy)
        {
            currentEnergy = startingEnergy;
        }
        currentEnergy -= currentLossRate * Time.deltaTime;
        energySlider.value = currentEnergy;
    }

    void healthManager()
    {
        if (isHit)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isHit = false;

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