using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UzairStartScreen : MonoBehaviour {
    public Text part1;
    public Text part2;
    public Text part3;
    public Text part4;

    public Text nextButtonText;

    public int part = 1;

    private void Start()
    {
        part1.enabled = true;
        part2.enabled = false;
        part3.enabled = false;
        part4.enabled = false;
    }
    public void Begin()
    {
        //Begin the Game Scene
        SceneManager.LoadScene("Level");
    }

    public void showText()
    {
        //Increments part by one
        part += 1;
    }

    private void Update()
    {
        //enables which text to show. and 
        //changes button text to whats suitable

        switch (part){
            case 1:
                part1.enabled = true;
                part2.enabled = false;
                part3.enabled = false;
                part4.enabled = false;
                nextButtonText.text = "Instructions";
                return;

            case 2:
                part2.enabled = true;
                part1.enabled = false;
                part3.enabled = false;
                part4.enabled = false;
                nextButtonText.text = "Next";
                return;

            case 3:
                part3.enabled = true;
                part2.enabled = false;
                part1.enabled = false;
                part4.enabled = false;
                nextButtonText.text = "Next";
                return;

            case 4:
                part4.enabled = true;
                part2.enabled = false;
                part3.enabled = false;
                part1.enabled = false;
                nextButtonText.text = "Begin";
                return;

            case 5:
                Begin();
                return;
        }
    }
}
