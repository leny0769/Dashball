using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject settingsWindow;
    
    public GameObject settingsFirstButton, closeSettingsFirstButton;


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

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeSettingsFirstButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
