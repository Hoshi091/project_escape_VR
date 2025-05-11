using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource openSound;
    public AudioSource closeSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", true);
            if (openSound != null && !openSound.isPlaying)
                openSound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("isOpen", false);
            if (closeSound != null && !closeSound.isPlaying)
                closeSound.Play();
        }
    }
}

