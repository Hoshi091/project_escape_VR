using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

    public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Transform playerHead;
    public float distanceFromPlayer = 2f;

    [SerializeField] private InputActionAsset inputActions;

    private InputAction pauseAction;
    private bool isPaused = false;

    private void OnEnable()
    {
        // Nájde akciu "Pause" z ActionMapy "Gameplay"
        pauseAction = inputActions.FindActionMap("Gameplay").FindAction("Pause");
        pauseAction.Enable();
        pauseAction.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        pauseAction.performed -= OnPausePressed;
        pauseAction.Disable();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void OnPausePressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Pause pressed!");
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            PositionMenuInFrontOfPlayer();
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void PositionMenuInFrontOfPlayer()
{
    Vector3 forward = new Vector3(playerHead.forward.x, 0, playerHead.forward.z).normalized;
    Vector3 targetPos = playerHead.position + forward * distanceFromPlayer;

    pauseMenu.transform.position = targetPos;
    pauseMenu.transform.LookAt(playerHead.position);
    pauseMenu.transform.Rotate(0, 180, 0); // pretočiť čelom k hráčovi

    Debug.Log("Pause menu moved to: " + targetPos);
}

public void ResumeGame()
{
    isPaused = false;
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
}
    /*public void BackToMenu()
{
    Time.timeScale = 1f;
    pauseMenu.SetActive(false);

    if (menuSpawnPoint != null && playerHead != null)
    {
        Transform xrOrigin = playerHead.parent.parent; // XR Origin

        // Vypočítaj aktuálnu pozíciu hráča (hlavy) a cieľovú
        Vector3 currentHeadPos = playerHead.position;
        Vector3 targetHeadPos = menuSpawnPoint.position;

        // Posuň celý XR Origin tak, aby sa hlava dostala presne na cieľ
        Vector3 difference = targetHeadPos - currentHeadPos;
        xrOrigin.position += difference;

        // Vypočítaj smer kam sa kamera pozerá a požadovaný smer
        Vector3 currentForward = new Vector3(playerHead.forward.x, 0, playerHead.forward.z).normalized;
        Vector3 targetForward = new Vector3(menuSpawnPoint.forward.x, 0, menuSpawnPoint.forward.z).normalized;

        float angle = Vector3.SignedAngle(currentForward, targetForward, Vector3.up);

        // Otoč XR Origin okolo hráča
        xrOrigin.RotateAround(playerHead.position, Vector3.up, angle);
    }
}*/

public void BackToMenu()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}


}