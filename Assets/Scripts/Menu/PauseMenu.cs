using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    public GameObject settingsFirstButton, closeSettingsFirstButton, pauseFirstButton;

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }


    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }


    public void OnPause()
    {
        if (gameIsPaused && !settingsWindow.activeSelf)
        {
            Resume();
        }
        else if (gameIsPaused && settingsWindow.activeSelf)
        {
            CloseSettingsWindow();
        }
        else
        {
            Paused();
        }
    }


    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }


    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeSettingsFirstButton);
    }

}
