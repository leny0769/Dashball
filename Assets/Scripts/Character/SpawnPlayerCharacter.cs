using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;



public class SpawnPlayerCharacter : MonoBehaviour
{

    public PlayerInput input;
    
    private GameObject PlayerPanel0;
    private GameObject text0;
    private GameObject selectedCharacter0;

    private GameObject PlayerPanel1;
    private GameObject text1;    
    private GameObject selectedCharacter1;

    private GameObject PlayerPanel2;
    private GameObject text2;
    private GameObject selectedCharacter2;

    private GameObject PlayerPanel3;
    private GameObject text3;
    private GameObject selectedCharacter3;

    private void Awake()
    {
        PlayerPanel0 = FindInActiveObjectByName("PlayerPanel0");
        text0 = FindInActiveObjectByName("AddPlayerText0");
        selectedCharacter0 = FindInActiveObjectByName("SelectedCharacter0");

        PlayerPanel1 = FindInActiveObjectByName("PlayerPanel1");
        text1 = FindInActiveObjectByName("AddPlayerText1");
        selectedCharacter1 = FindInActiveObjectByName("SelectedCharacter1");

        PlayerPanel2 = FindInActiveObjectByName("PlayerPanel2");
        text2 = FindInActiveObjectByName("AddPlayerText2");
        selectedCharacter2 = FindInActiveObjectByName("SelectedCharacter2");

        PlayerPanel3 = FindInActiveObjectByName("PlayerPanel3");
        text3 = FindInActiveObjectByName("AddPlayerText3");
        selectedCharacter3 = FindInActiveObjectByName("SelectedCharacter3");
        /*var selectMenu = GameObject.Find("SelectPanel");
        if(selectMenu != null)
        {
            var menu = Instantiate(playerSetUpMenuPrefab,selectMenu.transform);
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<playSetUp>().SetPlayerIndex(input.playerIndex);
        } */

        switch (input.playerIndex)
            {
                case 0:        PlayerPanel0.SetActive(true);
                                selectedCharacter0.GetComponent<CharacterManager>().SetPlayerIndex(input);
                                text0.SetActive(false);
                                Debug.Log("payer "+ input.playerIndex );
                    break;
                case 1:        PlayerPanel1.SetActive(true);
                                selectedCharacter1.GetComponent<CharacterManager>().SetPlayerIndex(input);
                                text1.SetActive(false);
                                Debug.Log("payer "+ input.playerIndex );
                    break;
                case 2:        PlayerPanel2.SetActive(true);
                                selectedCharacter2.GetComponent<CharacterManager>().SetPlayerIndex(input);
                                text2.SetActive(false);
                                Debug.Log("payer "+ input.playerIndex );
                    break;
                case 3:        PlayerPanel3.SetActive(true);
                                selectedCharacter3.GetComponent<CharacterManager>().SetPlayerIndex(input);
                                text3.SetActive(false);
                                Debug.Log("payer "+ input.playerIndex );
                    break;
                default: Debug.Log("payer "+ input.playerIndex + " can't exist");
                    break;
            }
    }


    public  GameObject FindInActiveObjectByName(string name)
    {
    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    for (int i = 0; i < objs.Length; i++)
    {
        if (objs[i].hideFlags == HideFlags.None)
        {
            if (objs[i].name == name)
            {
                return objs[i].gameObject;
            }
        }
    }
    return null;
    }
}

