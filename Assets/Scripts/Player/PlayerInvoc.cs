using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoc : MonoBehaviour
{

    public PlayerConfig playerConfig {get; set;}
    [SerializeField]
    private SpriteRenderer artworkSprite;
    [SerializeField]
    private Animator animator;
    public CharacterDatabase characterDB;


    public void PlayerInit(PlayerConfig pc)
    {
    playerConfig = pc;
    Character character = characterDB.GetCharacter(playerConfig.character);
    artworkSprite.sprite = character.characterSprite;
    animator.runtimeAnimatorController = character.characterAnimator;
    }
}
