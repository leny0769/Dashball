using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static string mapScene;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "MainMenu" && scene.name != "MapSelectionMenu" && scene.name != "CharacterSelectionMenu")
        {
            Destroy(GameObject.Find("AudioManager"));
        }
    }
}
