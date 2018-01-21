using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UzairPlayerHealth : UzairBaseHealth {
    
    public Slider healthSlider;
    public Image damageImage;
 
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        movement = GetComponent<UzairBaseController>();
        spotLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }

    protected override void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        movement.enabled = false;
    }

    protected override void HitMethod(Vector3 hitPoint, int knockBack)
    {
        return;
        //rg.AddExplosionForce(knockBack, hitPoint, 10);
    }
}