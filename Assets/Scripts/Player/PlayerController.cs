using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D _rigidbody;
    private Vector2 movementDirection;
    float AxisX, AxisY;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(AxisX, AxisY);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }


    public void OnHorizontal(InputValue  val)
    {
        AxisX = val.Get<float>();
    }


    public void OnVertical(InputValue val)
    {
        AxisY = val.Get<float>();
    }

}
