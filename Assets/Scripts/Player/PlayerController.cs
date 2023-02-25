using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    private Vector2 move; //


    //points d'accroche des attaques
    public Transform attackPointUp;
    public Transform attackPointUpRight;
    public Transform attackPointRight;
    public Transform attackPointDownRight;
    public Transform attackPointDown;
    public Transform attackPointDownLeft;
    public Transform attackPointLeft;
    public Transform attackPointUpLeft;

    private float attackRadius = 2.0f; //rayon dans lequel la balle peut être frapper
    public LayerMask ballLayer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * movementSpeed); //moves according to OnMove actions
    }

    private void OnMove(InputValue val)  //Listening movement inputs (zqsd/wasd)
    {
        move = val.Get<Vector2>();
    }



   /* private void OnMoveStick(InputValue val)   //à tester avec une manette si ça fonctionne sans ça alors ça dégage <3
    {
        move = val.Get<Vector2>();
    }*/



    /*void Hit()
    {
        Collider2D[] hit;
        if (animator.GetFloat("Vertical") >= 0 && animator.GetFloat("Horizontal") == 0) // 12h
        {
            hit = Physics2D.OverlapCircleAll(attackPointUp.position, attackRadius, ballLayer);
        }
       else if (animator.GetFloat("Vertical") >= 0 && animator.GetFloat("Horizontal") >= 0) // 1h30
        {
            hit = Physics2D.OverlapCircleAll(attackPointUpRight.position, attackRadius, ballLayer);
        }
       else if (animator.GetFloat("Vertical") == 0 && animator.GetFloat("Horizontal") >= 0) // 3h
        {
            hit = Physics2D.OverlapCircleAll(attackPointRight.position, attackRadius, ballLayer);
        }
        else if (animator.GetFloat("Vertical") <= 0 && animator.GetFloat("Horizontal") >= 0) // 4h30
        {
            hit = Physics2D.OverlapCircleAll(attackPointDownRight.position, attackRadius, ballLayer);
        }
        else if (animator.GetFloat("Vertical") <= 0 && animator.GetFloat("Horizontal") == 0) // 6h
        {
            hit = Physics2D.OverlapCircleAll(attackPointDown.position, attackRadius, ballLayer);
        }
        else if (animator.GetFloat("Vertical") <= 0 && animator.GetFloat("Horizontal") <= 0) // 7h30
        {
            hit = Physics2D.OverlapCircleAll(attackPointDownLeft.position, attackRadius, ballLayer);
        }
        else if (animator.GetFloat("Vertical") == 0 && animator.GetFloat("Horizontal") <= 0) // 9h
        {
            hit = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRadius, ballLayer);
        }
        else if (animator.GetFloat("Vertical") >= 0 && animator.GetFloat("Horizontal") <= 0) // 10h30
        {
            hit = Physics2D.OverlapCircleAll(attackPointUpLeft.position, attackRadius, ballLayer);
        }

        foreach (Collider2D ball in hit)
        {
            if(ball.gameObject.tag == "Ball")
            {
                Debug.Log("ça marche" + ball.gameObject.name);
            }
        }

        
    }*/

}

