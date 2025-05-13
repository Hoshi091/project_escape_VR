using UnityEngine;

public class CardScanner : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource audioSource;          
    private bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyCard") && !isUnlocked)
        {
            Debug.Log("Keycard scanned! Opening door...");
            isUnlocked = true;

            // Trigger door animation
            doorAnimator.SetTrigger("Open");

            // Play sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
