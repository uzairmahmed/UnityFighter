using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UzairPlayerHealth : UzairBaseHealth {
    
    public Slider healthSlider;
    public Image damageImage;

    public Slider energySlider;

    public float startingEnergy = 100;
    public float currentEnergy;

    public int energyLossRate = 2;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();

        currentEnergy = startingEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        energyManager();
    }

    void energyManager()
    {
        currentEnergy -= energyLossRate * Time.deltaTime;
        energySlider.value = currentEnergy;
    }

    protected override void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;
    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        healthSlider.value = currentHealth;
    }
}