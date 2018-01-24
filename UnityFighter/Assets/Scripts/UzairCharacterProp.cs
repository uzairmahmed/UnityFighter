using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Just the properties of the character.
 * Mainly for the zombie differentiation
 * but the player still uses it
 **/

public class UzairCharacterProp : MonoBehaviour {
    
    //starting and maximum health
    public float startingHealth;

    //movement speed (set on animators and Navmeshes)
    public float speed;

    //attackDamage and intervals
    public int attackDamage;
    public float attackInterval;

    //size
    public float scale;
    

    //i think an Enum would have been a better implementation of this
}
