using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMapMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(GameManage.mapScene);
    }
}
