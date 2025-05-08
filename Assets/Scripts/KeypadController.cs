using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string correctCode = "123";
    public GameObject indicatorCube;
    public AudioSource successSound;
    public AudioSource failSound;
    public Animator doorAnimator;
    public string openTriggerName = "Open";

    private string currentInput = "";
    private List<KeypadButton> pressedButtons = new List<KeypadButton>();

    public void PressKey(string key, KeypadButton button)
    {
        currentInput += key;
        pressedButtons.Add(button);

        if (currentInput.Length >= correctCode.Length)
        {
            bool correct = currentInput == correctCode;

            if (correct)
            {
                Debug.Log("Correct Code!");
                indicatorCube.GetComponent<Renderer>().material.color = Color.green;
                successSound?.Play();
                doorAnimator?.SetTrigger(openTriggerName); 
            {
                Debug.Log("Wrong Code.");
                indicatorCube.GetComponent<Renderer>().material.color = Color.red;
                failSound?.Play();
            }

            StartCoroutine(ResetAfterDelay()); 
        }
    }
    }

    private IEnumerator ResetAfterDelay() 
    {
        yield return new WaitForSeconds(1f);

        currentInput = "";

        foreach (var btn in pressedButtons)
        {
            btn.ResetButton();
        }

        pressedButtons.Clear();
    }
}
