using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreEnergie : MonoBehaviour
{
    private PlayerConfig[] playerConfigs;

    [SerializeField]
    private int id;
    // Start is called before the first frame update
    void Awake()
    {
        playerConfigs = Config.Instance.GetPlayerConfigs().ToArray();
        if(id > playerConfigs.Length)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Slider>().value = 0.2f;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(player.GetComponent<PlayerInvoc>().playerConfig.index == (id - 1))
                gameObject.GetComponent<Slider>().value = player.GetComponent<PlayerController>().SpecialCharge;
        }
    }
}
