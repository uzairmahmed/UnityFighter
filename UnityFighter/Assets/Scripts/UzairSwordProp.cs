using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairSwordProp : MonoBehaviour {

    int swordDamage = 25;
    int swordKnockBack = 5;

    public void setDamage(int dam)
    {
        swordDamage = dam;
    }

    public int getDamage()
    {
        return swordDamage;
    }

    public void setKnockback(int kbk)
    {
        swordKnockBack = kbk;
    }

    public int getKnockback()
    {
        return swordKnockBack;
    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
