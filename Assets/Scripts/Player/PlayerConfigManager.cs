using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfigManager : MonoBehaviour
{
    private List<PlayerConfig> playerconfigs;

    [SerializeField]
    int max_Player = 4;

    public static PlayerConfigManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance != null){
            Debug.Log("SINGLETON  trying to createinstance of singleton");
        }else{
            Instance = this;
            //DontDestroyOnLoad(Instance);
            playerconfigs = new  List<PlayerConfig>();
        }
    }

    public List<PlayerConfig> GetPlayerConfigs()
    {
        return playerconfigs;
    }
    public void SetPlayerCharacter(int index, int character)
    {
        playerconfigs[index].character = character;
    }

    public void HandlePlayer(PlayerInput pi){
        Debug.Log("play "+pi.playerIndex+ " joined");
        pi.transform.SetParent(transform);
        if(!playerconfigs.Any(p => p.index == pi.playerIndex)){
                playerconfigs.Add(new PlayerConfig(pi));
        }
    }
}

public class PlayerConfig
{
    public PlayerConfig(PlayerInput pi)
    {
        index = pi.playerIndex;
        input = pi;
        win = 0;
    }

    public PlayerInput input {get; set;}

    public int index {get; set;}

    public int character {get; set;}

    public int win {get; set;}

}