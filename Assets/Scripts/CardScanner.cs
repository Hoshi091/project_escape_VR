using UnityEngine;

public class CardScanner : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyCard") && !isUnlocked)
        {
            Debug.Log("Keycard scanned! Opening door...");
            isUnlocked = true;
            doorAnimator.SetTrigger("Open");
        }
    }
}
