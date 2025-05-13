using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour
{
    public GameObject map;
    public GameObject canvas;
    public AudioSource musicSource;

   
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            map.SetActive(false);
            canvas.SetActive(true);
            musicSource.Play();

        }
    }
}
