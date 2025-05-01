using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VRPhoneCall : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private XRGrabInteractable grabInteractable;
    private bool hasTriggered = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (hasTriggered) return;

        hasTriggered = true;

        string[] messages = new string[]
        {
            "911, what's your emergency?",
            "There's a shooter at the school!",
            "Stay calm. Are you in a safe location?",
            "I'm hiding in a club room, but they're right in the hallway.",
            "Don't worry, help is on the way.",
            "Okay... please hurry."
        };

        Color[] colors = new Color[]
        {
            Color.red,       // Dispatcher
            Color.white,      // Player
            Color.red,
            Color.white,
            Color.red,
            Color.white
        };

        dialogueManager.ShowDialogueSequence(messages, colors, 4f);
    }
}
