using System.Collections;
using UnityEngine;

public class KeyUnlockDoor : MonoBehaviour
{
    [Header("References")]
    public Animator doorAnimator;
    public string doorTriggerName = "Open";

    public AudioSource audioSource;
    public AudioClip insertSound;

    public string keyTag = "Key";
    public Transform keyTargetPosition;  // Final inserted position

    private bool isUnlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked) return;

        if (other.CompareTag(keyTag))
        {
            Debug.Log("Key detected, moving into lock.");

            // Disable grabbing
            var grab = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
            if (grab != null) grab.enabled = false;

            // Disable physics
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null) rb.isKinematic = true;

            // Start smooth movement to keyhole
            StartCoroutine(MoveKeyToLock(other.transform));

            // Play sound
            if (audioSource && insertSound)
                audioSource.PlayOneShot(insertSound);

            // Open door after delay
            if (doorAnimator != null)
                Invoke(nameof(OpenDoor), 1.2f);

            isUnlocked = true;
        }
    }

    private IEnumerator MoveKeyToLock(Transform key)
    {
        float duration = 1.0f; // seconds
        float elapsed = 0f;

        Vector3 startPos = key.position;
        Quaternion startRot = key.rotation;

        Vector3 endPos = keyTargetPosition.position;
        Quaternion endRot = keyTargetPosition.rotation;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, elapsed / duration);

            key.position = Vector3.Lerp(startPos, endPos, t);
            key.rotation = Quaternion.Slerp(startRot, endRot, t);

            yield return null;
        }

        // Final alignment
        key.position = endPos;
        key.rotation = endRot;
    }

    private void OpenDoor()
    {
        doorAnimator.SetTrigger(doorTriggerName);
    }
}
