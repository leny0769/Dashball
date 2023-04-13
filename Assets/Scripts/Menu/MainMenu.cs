using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject settingsWindow;
    public Button settingsButton;
    public Button playButton;
    public Button quitButton;


    void Update()
    {
        if (settingsWindow.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
           CloseSettingsButton();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        playButton.interactable = false;
        quitButton.interactable = false;
        settingsButton.interactable = false;
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        playButton.interactable = true;
        quitButton.interactable = true;
        settingsButton.interactable = true;
        settingsButton.Select();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
