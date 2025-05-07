using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeypadButton : MonoBehaviour
{
    public string keyValue;
    public KeypadController keypadController;
    public AudioSource pressSound;

    private Vector3 originalPosition;
    private bool isAnimating;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Press()
    {
        if (isAnimating) return;
        isAnimating = true;

        pressSound?.Play();
        keypadController.PressKey(keyValue);

        StartCoroutine(PressAnimation());
    }

    private IEnumerator PressAnimation()
    {
        Vector3 pressedPosition = new Vector3(
            originalPosition.x,
            originalPosition.y,
            0.055f // target Z value
        );

        transform.localPosition = pressedPosition;
        yield return new WaitForSeconds(0.1f); // hold for short feedback
        transform.localPosition = originalPosition;
        isAnimating = false;
    }
}