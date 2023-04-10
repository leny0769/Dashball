using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenu" || scene.name == "MapSelectionMenu")
        {
            foreach (var element in objects)
            {
                DontDestroyOnLoad(element);
            }
        }
    }
}
