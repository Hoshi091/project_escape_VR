using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string correctCode = "123";
    public GameObject indicatorCube; // light to change color
    public AudioSource successSound;
    public AudioSource failSound;

    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    
    private List<KeypadButton> pressedButtons = new List<KeypadButton>();
    private string currentInput = "";

public void PressKey(string key, KeypadButton button)
    {
        currentInput += key;
        pressedButtons.Add(button);

        if (currentInput.Length >= correctCode.Length)
        {
            if (currentInput == correctCode)
            {
                Debug.Log("Correct Code!");
                indicatorCube.GetComponent<Renderer>().material.color = Color.green;
                successSound?.Play();

                 OpenDoors();
            }
            else
            {
                Debug.Log("Wrong Code.");
                indicatorCube.GetComponent<Renderer>().material.color = Color.red;
                failSound?.Play();
            }

            StartCoroutine(ResetAfterDelay());
        }
    }

    private void OpenDoors()
    {
        if (leftDoorAnimator != null)
            leftDoorAnimator.SetTrigger("Open");

        if (rightDoorAnimator != null)
            rightDoorAnimator.SetTrigger("Open");
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