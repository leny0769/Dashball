using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public PlayerInput pi;
    public CharacterDatabase characterDB;

    private Text nameText;
    private Image artworkSprite;

    private GameObject sprite;
    private GameObject name;

    float AxisX;
    Vector2 Axis;


    private int selectedOption = 0;
    // Start is called before the first frame update
    
    void Awake()
    {
        int index = pi.playerIndex;
            switch (index)
            {
                case 0:sprite = FindInActiveObjectByName("SelectedCharacter0");  
                       name = FindInActiveObjectByName("Character Name 0");  
                    break;
                case 1:sprite = FindInActiveObjectByName("SelectedCharacter1");    
                       name = FindInActiveObjectByName("Character Name 1"); 
                    break;        
                case 2:sprite = FindInActiveObjectByName("SelectedCharacter2"); 
                       name = FindInActiveObjectByName("Character Name 2");    
                    break;
                case 3:sprite = FindInActiveObjectByName("SelectedCharacter3"); 
                       name = FindInActiveObjectByName("Character Name 3");    
                    break;
                        default: Debug.Log("payer "+ index + " can't exist");
                    break;
            }
            artworkSprite = sprite.GetComponent<Image>();
            nameText = name.GetComponent<Text>();
    }
    private void OnSelect(InputValue  val)
    {
        if(SceneManager.GetActiveScene().name == "CharacterSelectionMenu"){
            Axis = val.Get<Vector2>();
            AxisX = Axis.x;
            
            if(AxisX>0)
            {
            NextOption();
            }
            if(AxisX<0)
            {
            BackOption();
        }
        }
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {

        PlayerConfigManager.Instance.SetPlayerCharacter(pi.playerIndex,selectedOption);
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;

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
