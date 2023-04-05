using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject[] couronnes;
    private PlayerConfig[] playerConfigs;


    
    // Start is called before the first frame update
    void Awake()
    {

        playerConfigs = Config.Instance.GetPlayerConfigs().ToArray();
        if(id > playerConfigs.Length)
        {
            gameObject.SetActive(false);
        }
        foreach(var pc in playerConfigs)
        {
            if(pc.index == id - 1)
            {

                for(int i =0;i< pc.win;i++)
                {
                    Debug.Log(i);
                    couronnes[i].GetComponent<Toggle>().isOn=true;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
