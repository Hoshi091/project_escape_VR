using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI dialogueText;

    private Coroutine currentDialogue;

    public void ShowDialogueSequence(string[] messages, Color[] colors, float interval = 4f)
    {
        if (currentDialogue != null)
            StopCoroutine(currentDialogue);

        currentDialogue = StartCoroutine(DisplayDialogue(messages, colors, interval));
    }

    private IEnumerator DisplayDialogue(string[] messages, Color[] colors, float interval)
    {
        dialogueCanvas.SetActive(true);

        for (int i = 0; i < messages.Length; i++)
        {
            dialogueText.color = colors[i];
            dialogueText.text = messages[i];
            yield return new WaitForSeconds(interval);
        }

        dialogueCanvas.SetActive(false);
        currentDialogue = null;
    }
}
