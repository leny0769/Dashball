using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoc : MonoBehaviour
{

    private PlayerConfig playerConfig;
    [SerializeField]
    private SpriteRenderer artworkSprite;
    public CharacterDatabase characterDB;


    public void PlayerInit(PlayerConfig pc)
    {
    playerConfig = pc;
    Character character = characterDB.GetCharacter(playerConfig.character);
    artworkSprite.sprite = character.characterSprite;
    }
}
