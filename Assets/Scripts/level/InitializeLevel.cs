using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns; 
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private string level;
    // Start is called before the first frame update
    private PlayerConfig[] playerConfigs;
    void Start()
    {
        playerConfigs = Config.Instance.GetPlayerConfigs().ToArray();
        for(int i =0; i< playerConfigs.Length;i++)
        {
            var player = Instantiate(playerPrefab,playerSpawns[i].position,playerSpawns[i].rotation,gameObject.transform);
            player.GetComponent<PlayerInvoc>().PlayerInit(playerConfigs[i]);
        }
    }

    void Update() 
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length <= 1) 
        {
            win();
        }
    }

    public void win()
    {
            foreach (GameObject winner in GameObject.FindGameObjectsWithTag("Player"))
            {
                PlayerConfig winnerCongig = winner.GetComponent<PlayerInvoc>().playerConfig;
                winnerCongig.win++;
                Config.Instance.updatePC(winnerCongig);
                Debug.Log("Win P"+winnerCongig.index);
            }
            SceneManager.LoadScene(level);
    }

}
