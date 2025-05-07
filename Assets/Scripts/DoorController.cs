using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log($"Trigger entered by: {other.name}, tag: {other.tag}, layer: {LayerMask.LayerToName(other.gameObject.layer)}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Opening doors...");

            if (leftDoorAnimator != null)
                leftDoorAnimator.SetTrigger("Open");

            if (rightDoorAnimator != null)
                rightDoorAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Closing doors...");

            if (leftDoorAnimator != null)
                leftDoorAnimator.SetTrigger("Close");

            if (rightDoorAnimator != null)
                rightDoorAnimator.SetTrigger("Close");
        }
    }
}
