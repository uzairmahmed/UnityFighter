using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzairGameManager : MonoBehaviour {
    public GameObject type1Zom;
    public GameObject type2Zom;
    public GameObject type3Zom;

    public ArrayList ZombieArray = new ArrayList();

    GameObject[] spawners = new GameObject[8];

    public UzairSwordProp sword;

    public int swordDamage;

    public int currentWave;
    public int waveSize = 5;
    public int waveIncrease = 2;
    public int zombiesLeft;

    // Use this for initialization
    void Start () {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        currentWave = 1;
	}
	
	// Update is called once per frame
	void Update () {
        zombiesLeft = ZombieArray.Count;
        if (zombiesLeft <= 0)
        {
            currentWave += 1;
            NextWave(currentWave);
        }
        swordDamage = sword.getDamage();
    }

    public void SpawnZombie()
    {
        int type = (int)(3 * Random.value);
        switch (type)
        {
            case 0:
                Instantiate(type1Zom, GetZombieSpawner(), Quaternion.identity, gameObject.transform);
                return;

            case 1:
                Instantiate(type2Zom, GetZombieSpawner(), Quaternion.identity, gameObject.transform);
                return;

            case 2:
                Instantiate(type3Zom, GetZombieSpawner(), Quaternion.identity, gameObject.transform);
                return;
        }
    }

    public void NextWave(int wave)
    {
        int size = wave * waveIncrease;
        for (int i = 0; i < size; i++)
        {
            SpawnZombie();
        }
        sword.setDamage(sword.getDamage()+10);
    }

    public Vector3 GetZombieSpawner()
    {
        return spawners[(int)(spawners.Length * (Random.value))].transform.position;
    }
    
}
