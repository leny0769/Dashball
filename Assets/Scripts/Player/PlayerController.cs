using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    //private Rigidbody2D _rigidbody;
    private Vector2 moveInputValue;
    float AxisX, AxisY;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        transform.Translate(moveInputValue * movementSpeed * Time.deltaTime);
    }

    public void OnMoveHorizontal(InputValue  val)
    {
        AxisX = val.Get<float>();
        moveInputValue = new Vector2(AxisX, AxisY);
        moveInputValue.Normalize();
    }


    public void OnMoveVertical(InputValue val)
    {
        AxisY = val.Get<float>();
        moveInputValue = new Vector2(AxisX, AxisY);
        moveInputValue.Normalize();
    }

    public void OnMoveStick(InputValue val)
    {
        moveInputValue = val.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

}
