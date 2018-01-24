using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/**
 * this pretty much runs everything.
 * Actually tho, 
 * >    It manages the number of zombies in the world
 * >    Spawns waves of zombies accordingly
 * >    Writes ALL the text to the UI
 * >    Runs the GameOver Function
 **/

public class UzairGameManager : MonoBehaviour {

    //Every UI text element
    public Text waveText;
    public Text timerText;
    public Text swordText;
    public Text enemyText;
    public Text endText;

    //Every game camera
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    //World timers
    public float startTimer;
    public string deathTimer;

    //Player health info
    public UzairPlayerHealth playerHealth;

    //Player Sword and damage
    public UzairSwordProp sword;
    public int swordDamage;

    //The zombie types
    public GameObject type1Zom;
    public GameObject type2Zom;
    public GameObject type3Zom;

    //Arraylist of zombies
    public ArrayList ZombieArray = new ArrayList();

    //Location of each spawnable area
    GameObject[] spawners = new GameObject[8];
    
    //How big the wave is, the factor it increases by each time
    public int waveSize = 5;
    public int waveIncrease = 2;

    //the current wave and # of zombies left
    public int currentWave;
    public int zombiesLeft;

    // Use this for initialization
    void Start()
    {
        //Starts the timer
        startTimer = Time.time;

        //enables the main camera, the zoomed out camera, 
        //but disables the heaven camera
        cam1.enabled = true;
        cam2.enabled = true;
        cam3.enabled = false;
        
        //Gets all the spwan points for zombies
        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        //sets the current wave to zero
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //counts the number of zombies in the array
        zombiesLeft = ZombieArray.Count;

        //updates the sword damage value
        swordDamage = sword.getDamage();

        //updates the UI text for number of enemies and time
        enemyText.text = (zombiesLeft + " Zombies Left");
        timerText.text = ("Time: " + CurrentTime() + " seconds.");

        //if there are no zombies, increase the wave by one, and spawn a new wave
        if (zombiesLeft <= 0)
        {
            currentWave += 1;
            NextWave(currentWave);
        }
        
        //check if the player is alive
        if (playerHealth.isDead)
        {
            //No? GAME OVER
            GameOver();
        }
        else if (!playerHealth.isDead)
        {
            //otherwose, continue the timer for his death. (<-- that is very dark)
            deathTimer = CurrentTime();
        }
    }

    //runs the game over function
    public void GameOver()
    {
        //enables the camera in heaven
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = true;

        //and updates the text
        waveText.text = "GAME OVER";
        endText.text = "You Survived " + currentWave + " Waves, " + "For " + deathTimer + " Seconds.";
    }

    //spawns the next wave and does some upgrades
    public void NextWave(int wave)
    {
        //increases the wave size
        int size = wave * waveIncrease;
        //spawns x number of zombies
        for (int i = 0; i < size; i++)
        {
            SpawnZombie();
        }

        //upgrades the sword
        sword.setDamage(sword.getDamage() + 10);

        //updates the UI Info
        waveText.text = "Wave " + currentWave;
        waveText.color = Color.red;
        swordText.text = "Sword Level " + wave;
        swordText.color = Color.red;
    }

    //Spawn a single zombie
    public void SpawnZombie()
    {
        //get a random type of zombie, and spawn it
        int type = (int)(3 * Random.value);
        switch (type) { 
        
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
        
    //get a random zombie spawner
    public Vector3 GetZombieSpawner()
    {
        return spawners[(int)(spawners.Length * (Random.value))].transform.position;
    }

    //gets the current time since the game began (in seconds)
    public string CurrentTime()
    {
        float t = ((int)(((Time.time - startTimer) % 60) * 10));
        return (t / 10).ToString();
    }
}
