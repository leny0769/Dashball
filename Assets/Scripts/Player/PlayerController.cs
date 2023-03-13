using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector2 moveInputValue;
    float AxisX, AxisY;

    // Start is called before the first frame update
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        transform.Translate(moveInputValue * movementSpeed * Time.deltaTime);
    }

    private void OnMoveHorizontal(InputValue  val)
    {
        AxisX = val.Get<float>();
        moveInputValue = new Vector2(AxisX, AxisY);
        moveInputValue.Normalize();
    }


    private void OnMoveVertical(InputValue val)
    {
        AxisY = val.Get<float>();
        moveInputValue = new Vector2(AxisX, AxisY);
        moveInputValue.Normalize();
    }

    private void OnMoveStick(InputValue val)
    {
        moveInputValue = val.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    

}
