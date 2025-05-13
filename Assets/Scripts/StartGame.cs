using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public DialogueManager dialogueManager;
  

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            Debug.Log("Presiel");

            string[] messages = new string[]
       {
           "Musím najst spôsob ako sa dostať cez hlavný vchod"

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
