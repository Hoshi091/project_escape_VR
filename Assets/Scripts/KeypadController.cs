using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string correctCode = "123";
    public GameObject indicatorCube; // light to change color
    public AudioSource successSound;
    public AudioSource failSound;

    private string currentInput = "";

    public void PressKey(string key)
    {
        currentInput += key;

        if (currentInput.Length >= correctCode.Length)
        {
            if (currentInput == correctCode)
            {
                Debug.Log("Correct Code!");
                indicatorCube.GetComponent<Renderer>().material.color = Color.green;
                successSound?.Play();
                // TODO: unlock door or trigger event
            }
            else
            {
                Debug.Log("Wrong Code.");
                indicatorCube.GetComponent<Renderer>().material.color = Color.red;
                failSound?.Play();
            }

            currentInput = ""; // reset
        }
    }
}