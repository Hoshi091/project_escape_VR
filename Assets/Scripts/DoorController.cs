using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator leftDoorAnimator;  
    public Animator rightDoorAnimator; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Opening hallway doors...");
            leftDoorAnimator.SetTrigger("Open");
            rightDoorAnimator.SetTrigger("Open");
        }
    }
}
