using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UzairGameManager : MonoBehaviour {
    public GameObject type1Zom;
    public GameObject type2Zom;
    public GameObject type3Zom;

    public Text waveText;
    public Text timerText;
    public Text swordText;
    public Text enemyText;

    public float startTimer;

    public ArrayList ZombieArray = new ArrayList();

    GameObject[] spawners = new GameObject[8];

    public UzairSwordProp sword;

    public int swordDamage;

    public int currentWave;
    public int waveSize = 5;
    public int waveIncrease = 2;
    public int zombiesLeft;

    public float textPulse = 50f;

    // Use this for initialization
    void Start () {
        startTimer = Time.time;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        currentWave = 0;
	}

    // Update is called once per frame
    void Update()
    {
        zombiesLeft = ZombieArray.Count;
        if (zombiesLeft <= 0)
        {
            currentWave += 1;
            NextWave(currentWave);
        }
        swordDamage = sword.getDamage();
        enemyText.text = (zombiesLeft + " Zombies Left");
        timerText.text = ("Time: " + CurrentTime() + " seconds.");
    }
    

    public string CurrentTime()
    {
        float t = ((int)(((Time.time - startTimer)%60)*10));
        return (t/10).ToString();
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
        
        waveText.text = "Wave " + currentWave;
        waveText.color = Color.red;
        swordText.text = "Sword Level " + wave;
        swordText.color = Color.white;

    }

    public Vector3 GetZombieSpawner()
    {
        return spawners[(int)(spawners.Length * (Random.value))].transform.position;
    }
    
}
