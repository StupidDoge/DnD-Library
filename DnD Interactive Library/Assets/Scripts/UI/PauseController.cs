using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool GameIsPaused;

    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private InputHandler _inputHandler;

    private void Update()
    {
        if (InteractionCollider.CanvasIsActive && _inputHandler.Exit)
        {
            if (GameIsPaused)
                ContinueGame();
            else
                PauseGame();
        }

        Debug.Log(InteractionCollider.CanvasIsActive);
    }

    private void PauseGame()
    {
        _pauseCanvas.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ContinueGame()
    {
        _pauseCanvas.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
