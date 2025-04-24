using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    /*
    
    ROADMAP

    1- pressing the button to start the game
        begin with a blank screen
        then when the button is pressed open the actual menu GUI

    2- opening page 31

    3- finishing 63-11

    4- inputting the number of ks on 82 (are you sure?) (are you really sure?) (are you super duper sure?)

    -> press space to close the game... but before you do, count the number of...

    -> goes to karateka

    */

    public GameObject page;
    public GameObject firstKey;
    public GameObject secondKey;
    public TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    int stage = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1") && stage == 0)
        {
            // We press the start button
            print(1);
            text.text = "Go to page 31.";
            stage++;
        }
        if(Input.GetKeyDown("2") && stage == 1)
        {
            // We land on page 31 and open it
            print(2);
            page.SetActive(true);
            stage++;
        }
        if(Input.GetKeyDown("3") && stage == 2)
        {
            // 63-11
            print(3);
            firstKey.SetActive(true);
            stage++;
        }
        if(Input.GetKeyDown("4") && stage == 3)
        {
            // Number of ks
            print(2);
            secondKey.SetActive(true);
            stage++;
        }
    }
}
