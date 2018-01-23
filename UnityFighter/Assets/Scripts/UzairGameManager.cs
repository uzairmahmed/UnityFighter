using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairGameManager : MonoBehaviour {
    public GameObject type1Zom;
    public GameObject type2Zom;
    public GameObject type3Zom;

    public ArrayList ZombieArray = new ArrayList();

    public int arSiz;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 10; i++)
        {
            SpawnZombie();
        }
	}
	
	// Update is called once per frame
	void Update () {

        arSiz = ZombieArray.Count;
	}

    public void SpawnZombie()
    {
        int type = (int)(3 * Random.value);
        switch (type)
        {
            case 0:
                Instantiate(type1Zom, gameObject.transform);
                return;

            case 1:
                Instantiate(type2Zom, gameObject.transform);
                return;

            case 2:
                Instantiate(type3Zom, gameObject.transform);
                return;
        }
    }
    
}
