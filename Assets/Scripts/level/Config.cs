using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance {get; private set;}

    private List<PlayerConfig> playerConfigs;

    private void Awake()
    {
        if (Instance != null){
            Debug.Log("SINGLETON  trying to createinstance of singleton");
        }else{
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        
    }

    public void save()
    {
        playerConfigs = PlayerConfigManager.Instance.GetPlayerConfigs();
    }

    public List<PlayerConfig> GetPlayerConfigs()
    {
        return playerConfigs;
    }
}
