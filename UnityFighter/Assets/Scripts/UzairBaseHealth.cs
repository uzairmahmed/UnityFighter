using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairBaseHealth : MonoBehaviour {

    protected Animator anim;
    protected Rigidbody rg;
    protected UzairBaseController movement;
    public Light spotLight;

    protected bool isDead;
    protected bool isHit;

    public int startingHealth = 100;
    public int currentHealth;

    public Color hitColor = new Color(1f, 0f, 0.1f);
    public float flashSpeed = 10f;

	// Use this for initialization
	void Start () {

        currentHealth = startingHealth;
        spotLight.color = hitColor;
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit)
        {
            //Light the Red Spotlight
            spotLight.color = hitColor;
        }
        else
        {
            spotLight.color = Color.Lerp(hitColor, Color.clear, flashSpeed * Time.deltaTime);
        }
        isHit = false;
	}

    public void TakeDamage(int amount, Vector3 hitPoint, int knockback)
    {
        if (isDead)
        {
            return;
        }

        isHit = true;
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        HitMethod(hitPoint, knockback);

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }

    protected virtual void Death()
    {
        return;
    }

    protected virtual void HitMethod(Vector3 hitPoint, int knockBack)
    {
        return;
    }
}
