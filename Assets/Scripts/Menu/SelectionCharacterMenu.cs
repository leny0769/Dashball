using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCharacterMenu : MonoBehaviour
{
    //public string[] level;
    private PlayerConfig[] playerConfigs;
    
    public void StartGame()
    {
        
        if(SceneManager.GetActiveScene().name == "CharacterSelectionMenu"){ Config.Instance.save();}
        //party win condition   
        //load one random level
        //int index = Random.Range(0, level.Length);

        string levelToLoad ="MapSelectionMenu";
        playerConfigs = Config.Instance.GetPlayerConfigs().ToArray();
        if(SceneManager.GetActiveScene().name == "ScoreBoard")
        {
            
            playerConfigs = Config.Instance.GetPlayerConfigs().ToArray();
            foreach(var pc in playerConfigs)
            {   
                if(pc.win >= 5)
                {
                    Debug.Log("test");
                    levelToLoad ="CharacterSelectionMenu";
                }
            }
                    
        }
    
        Debug.Log("level load : " + levelToLoad);
        if(playerConfigs.Length > 1)
            SceneManager.LoadScene(levelToLoad);
        else
        {
            Debug.Log("at least 2 player");
        }
    }

}
