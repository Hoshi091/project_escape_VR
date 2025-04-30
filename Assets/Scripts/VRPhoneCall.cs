using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPhoneCall : MonoBehaviour
{
    public DialogueManager dialogueManager; 
    public string message = "Calling the cops...";

    private XRGrabInteractable grabInteractable;
    private bool hasTriggered = false;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!hasTriggered)
        {
            dialogueManager.ShowDialogue(message);
            hasTriggered = true; // prevents repeated calls
        }
    }
}
