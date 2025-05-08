using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDebugEvents : MonoBehaviour
{
    void OnEnable()
    {
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    void OnDisable()
    {
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEntered);
            interactable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log($"[XR Debug] Hovered on: {gameObject.name}");
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log($"[XR Debug] Selected: {gameObject.name}");
    }
}