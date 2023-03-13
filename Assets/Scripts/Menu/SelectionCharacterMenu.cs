using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCharacterMenu : MonoBehaviour
{
    public string levelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}