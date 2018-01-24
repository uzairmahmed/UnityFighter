using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public void Begin()
    {
        //Begin the Game Scene
        SceneManager.LoadScene("Level");
    }
}
