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
private Renderer rend;
    private bool isPressed = false;

    private void Start()
    {
        originalPosition = transform.localPosition;
        rend = GetComponent<Renderer>();
    }

    public void Press()
    {
        if (isPressed) return;
        isPressed = true;

        transform.localPosition = new Vector3(
            originalPosition.x,
            originalPosition.y,
            0.055f
        );

        SetEmission(true);
        pressSound?.Play();
        keypadController.PressKey(keyValue, this); // Pass reference to self
    }

    public void ResetButton()
    {
        transform.localPosition = originalPosition;
        SetEmission(false);
        isPressed = false;
    }

    // Hover Glow ON
    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        SetEmission(true);
    }

    // Hover Glow OFF
    public void OnHoverExit(HoverExitEventArgs args)
    {
        SetEmission(false);
    }

    private void SetEmission(bool on)
    {
        if (rend == null) return;

        if (on)
        {
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", Color.yellow); // glowing yellow
        }
        else
        {
            rend.material.DisableKeyword("_EMISSION");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log($"Button '{gameObject.name}' pressed by {other.name}");
            Press();
        }
    }
}
