using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public Image artworkSprite;

    private int selectedOption = 0;
    private int index;
    private PlayerInput pi;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
    }


    public void SetPlayerIndex(PlayerInput pi){
        index = pi.playerIndex;
    }



    private void UpdateCharacter(int selectedOption)
    {

        PlayerConfigManager.Instance.SetPlayerCharacter(index,selectedOption);
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

    }
}
