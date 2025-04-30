using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText; // or TMP_Text if using TextMeshPro
    public float displayTime = 4f;

    private float timer;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string message)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = message;
        timer = displayTime;
    }

    void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }
}
