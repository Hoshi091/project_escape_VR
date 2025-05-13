using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            musicSource.Play();

        }
    }
}
