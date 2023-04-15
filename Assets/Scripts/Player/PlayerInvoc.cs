using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoc : MonoBehaviour
{

    public PlayerConfig playerConfig {get; set;}
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer artworkSprite;
    public CharacterDatabase characterDB;


    void Start()
    {
        artworkSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void PlayerInit(PlayerConfig pc)
    {
    playerConfig = pc;
    Character character = characterDB.GetCharacter(playerConfig.character);
    artworkSprite.sprite = character.characterSprite;
    animator.runtimeAnimatorController = character.characterAnimator;
    }
}
