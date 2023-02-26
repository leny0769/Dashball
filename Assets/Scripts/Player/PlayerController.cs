using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    private Vector2 move;
    private Vector2 attack;

    //points d'accroche des attaques
    public Transform attackPointUp;
    public Transform attackPointUpRight;
    public Transform attackPointRight;
    public Transform attackPointDownRight;
    public Transform attackPointDown;
    public Transform attackPointDownLeft;
    public Transform attackPointLeft;
    public Transform attackPointUpLeft;

    public float attackRadius = 0.5f; //rayon dans lequel la balle peut être frapper
    public LayerMask ballLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    { 
        Move();
        Attack();
    }


    private void Move()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * movementSpeed); //moves according to OnMove actions
    }

    private void Attack()
    {
        Collider2D[] hit = null;

        if (attack.x == 0 && attack.y == 1) //Up
        {
            hit = Physics2D.OverlapCircleAll(attackPointUp.position, attackRadius, ballLayer);
        }
        else if (attack.x > 0 && attack.y > 0) //Up Right
        {
            hit = Physics2D.OverlapCircleAll(attackPointUpRight.position, attackRadius, ballLayer);
        }
        else if (attack.x == 1 && attack.y == 0) //Right
        {
            hit = Physics2D.OverlapCircleAll(attackPointRight.position, attackRadius, ballLayer);
        }
        else if (attack.x > 0 && attack.y < 0) //Down Right
        {
            hit = Physics2D.OverlapCircleAll(attackPointDownRight.position, attackRadius, ballLayer);
        }
        else if (attack.x == 0 && attack.y == -1) //Down
        {
            hit = Physics2D.OverlapCircleAll(attackPointDown.position, attackRadius, ballLayer);
        }
        else if (attack.x < 0 && attack.y < 0) //Down Left
        {
            hit = Physics2D.OverlapCircleAll(attackPointDownLeft.position, attackRadius, ballLayer);
        }
        else if (attack.x == 0 && attack.y == -1) //Left
        {
            hit = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRadius, ballLayer);
        }
        else if (attack.x < 0 && attack.y > 0) //Up Left
        {
            hit = Physics2D.OverlapCircleAll(attackPointUpLeft.position, attackRadius, ballLayer);
        }
        if (hit != null)
        {
            foreach (Collider2D ball in hit)
            {
                if (ball.gameObject.tag == "Ball")
                {
                    Debug.Log("ça marche " + ball.gameObject.name);
                    
                }
            }
        }

    }

    private void OnMove(InputValue val)  //Listening movement inputs (zqsd/wasd + left stick)
    {
        move = val.Get<Vector2>();
    }

    private void OnAttack(InputValue val) //Listening attack inputs (arrows
    {
        attack = val.Get<Vector2>();
    }


}

