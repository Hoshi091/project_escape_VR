using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI Referencia")]
    public GameObject mainMenuUI;

    void Start()
    {
        // Pauznuj hru na začiatku
        Time.timeScale = 0f;

        if (mainMenuUI != null)
            mainMenuUI.SetActive(true);
    }

    public void PlayGame()
    {
        if (mainMenuUI != null)
            mainMenuUI.SetActive(false);

        Time.timeScale = 1f; // Spusti hru
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}