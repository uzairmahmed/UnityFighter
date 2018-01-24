using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Properties for the Player Weapon. 
 * Nothing too fancy, just setter and getter 
 * methods for attack and knockback.
 **/

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
}
