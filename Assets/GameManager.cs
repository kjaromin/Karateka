using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private String[] entries = {
        "Press the button on page 1 to start the game.",
        "Turn to page 39."
    };

    int[] code = {4, 6, 1, 1};

    [SerializeField]
    private TMP_Text label;
    

    [SerializeField]
    private GameObject page;
    
    [SerializeField]
    private TMP_Text key1;
    
    [SerializeField]
    private TMP_InputField key2Input;

    [SerializeField]
    private TMP_Text key2Feedback;

    IEnumerator CorrectKey2(float delay)
    {
        // Player got the correct number of ks
        // Start the next phase of the game. Two options:
        
        // Option 1: Spawn text that shows instructions, then quit the game, reveal Karateka
        //      This is implemented below

        // Option 2: Make the game window transparent & click-through while the player plays Karateka
        //      More advanced but we can add more polish
        //      Idea: A paper-like border around the screen while the player plays Karateka
        //      Idea: Keep the keycode on screen so players don't forget

        key2Feedback.text = "Correct!";
        page.SetActive(false);
        key1.gameObject.SetActive(false);
        String karatekaPrompt = code[0].ToString() + ", " + code[1].ToString() + ", _, _. Remember these numbers...";
        label.text = karatekaPrompt;

        yield return new WaitForSeconds(delay);
        key2Input.gameObject.SetActive(false);
        key2Feedback.gameObject.SetActive(false);
        label.text = karatekaPrompt + " 3..";
        
        yield return new WaitForSeconds(1f);
        label.text = karatekaPrompt + " 2..";
        
        yield return new WaitForSeconds(1f);
        label.text = karatekaPrompt + " 1..";
        
        yield return new WaitForSeconds(1f);
        Application.Quit(); // Reveals Karateka
    }

    IEnumerator IncorrectKey2(float delay)
    {
        // Player got the incorrect number of ks
        // Flash incorrect and allow the player to retry

        key2Feedback.text = "Try again...";
        yield return new WaitForSeconds(delay);
        key2Feedback.text = "";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Setup
        label.text = entries[0];
        key1.text = code[0].ToString();
        key2Input.onEndEdit.AddListener(HandleSubmit);
    }

    
    void HandleSubmit(string text)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter was pressed with text: " + text);
            
            if (text.Equals(code[1].ToString()))
            {
                StartCoroutine(CorrectKey2(4f));

                // Debug
                // print(1);
            }
            else
            {
                StartCoroutine(IncorrectKey2(4f));

                // Debug
                // print(2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Esc to quick exit for debugging
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        
        // Each stage corresponds to numbers 1-3
        // This will be mapped to our corresponding controller buttons when finished
        if(Input.GetKeyDown("1")) label.text = entries[1]; // Player presses the start button
        if(Input.GetKeyDown("2")) page.SetActive(true); // Player turns to page 39
        if(Input.GetKeyDown("3")) // Player touches 63 to 11
        {
            key1.gameObject.SetActive(true);
            key2Input.gameObject.SetActive(true);
            key2Feedback.gameObject.SetActive(true);
        }
    }
}
