using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint2 : MonoBehaviour
{
    public DialogueManager dialogueManager;



    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            Debug.Log("Presiel");

            string[] messages = new string[]
        {
             "Hmm klubovna je zavreta",
             "nejaky strateny isic asi bude na vratnici"

        };

            Color[] colors = new Color[]
            {
            Color.white,
            Color.white,
            };

            dialogueManager.ShowDialogueSequence(messages, colors, 4f);
            Destroy(gameObject);

        }
    }
}
