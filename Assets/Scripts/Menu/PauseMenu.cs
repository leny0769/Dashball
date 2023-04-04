using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsWindow;


    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
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


    void OnPause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }


    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }


    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

}
