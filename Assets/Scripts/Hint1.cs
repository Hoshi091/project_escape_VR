using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint1 : MonoBehaviour
{

    public DialogueManager dialogueManager;



    private void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Presiel");

            string[] messages = new string[]
        {
             "Mozem skusit zavoalt policiu",
             "telefon by mal byt v klubovni"

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
