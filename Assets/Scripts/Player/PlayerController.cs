using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    public BallBehavior ball;

    private Vector2 move;
    private Vector2 attack;

    //points d'accroche des attaques
    public Transform attackPoint;

    public float attackRadius = 0.5f; //rayon dans lequel la balle peut ?tre frapper
    public LayerMask ballLayer;

    public AudioSource audioSource;
    public AudioClip sound; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball").GetComponent<BallBehavior>();
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    private void OnMove(InputValue val)  //Listening movement inputs (zqsd/wasd + left stick)
    {
        move = val.Get<Vector2>();
    }

    private void OnAttack(InputValue val) //Listening attack inputs (arrows)
    {
        attack = val.Get<Vector2>();
        attack.Normalize();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * movementSpeed); //moves according to OnMove actions
    }

    private void Attack()
    {
        Vector2 mem = attackPoint.position;
        Vector2 vecAttack = attackPoint.TransformPoint(Vector3.zero);
        vecAttack += attack;
        attackPoint.transform.position = vecAttack;
        Collider2D[] hit = null;
        hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, ballLayer);
        attackPoint.position = mem;

        if (hit != null)
        {
            foreach (Collider2D balle in hit)
            {
                if (balle.gameObject.tag == "Ball")
                {
                    if (!ball.GetHit())
                    {
                        ball.SetHit(true);
                        ball.SetSpeed(new Vector2(-1.5f * ball.GetSpeed().x, -1.5f * ball.GetSpeed().y));
                        StartCoroutine(Hit());

                        audioSource.PlayOneShot(sound);
                    }
                }
            }
        }
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.5f);
        ball.SetHit(false);

    }
}

