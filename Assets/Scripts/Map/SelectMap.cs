using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectMap : MonoBehaviour
{

    public MapDatabase mapDB;

    public Text nameText;
    public Image mapSprite;

    private int selectedOption = 0;
    private int index;

    float AxisX;
    Vector2 Axis;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMap(selectedOption);
    }

    private void OnSelect(InputValue val)
    {
        if (SceneManager.GetActiveScene().name == "MapSelectionMenu")
        {
            Axis = val.Get<Vector2>();
            AxisX = Axis.x;

            if (AxisX > 0)
            {
                NextOption();
            }
            if (AxisX < 0)
            {
                BackOption();
            }
        }
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= mapDB.MapCount)
        {
            selectedOption = 0;
        }

        UpdateMap(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = mapDB.MapCount - 1;
        }

        UpdateMap(selectedOption);
    }

    private void UpdateMap(int selectedOption)
    {

        Map map = mapDB.GetMap(selectedOption);
        mapSprite.sprite = map.mapImage;
        nameText.text = map.mapName;
        GameManage.mapScene = map.sceneName;
    }
}
