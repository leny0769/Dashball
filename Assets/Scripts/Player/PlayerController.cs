using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    public BallBehavior ball;

    private bool isSpecial = false;

    private Vector2 move;
    private Vector2 attack;

    //points d'accroche des attaques
    public Transform attackPoint;

    public float attackRadius = 0.5f; //rayon dans lequel la balle peut ?tre frapper
    public LayerMask ballLayer;

    public int SpecialCharge = 0;

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

    private void OnSpecial()
    {
        if (SpecialCharge ==4 )
        {
            SpecialCharge = 0;
            isSpecial = true;
        }
    }

    private void Move()
    {
            rb.MovePosition(rb.position + move * Time.fixedDeltaTime * movementSpeed); //moves according to OnMove actions
    }

    private void Attack()
    {
        // on passe la position du point d'attaque en coordonnees global pour pouvoir la sommer avec le vecteur
        // de la fonction OnAttack puis on test s'il y a un quelconque contact
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
                        if (!isSpecial)
                        {
                            //si la balle ne vient pas d'etre frapper (pour eviter qu'elle parte a mach20 apres 2s de match)
                            //alors on la rend non frappable, l'accelere en la renvoyant dans l'autre sens, puis on la rend de nouveau frappable apres 1/2s
                            StartCoroutine(Hit());

                            if (SpecialCharge < 4) SpecialCharge++;

                            audioSource.PlayOneShot(sound);
                        }
                        else
                        {
                            StartCoroutine(Special());
                        }
                    }
                }
            }
        }
    }

    IEnumerator Hit()
    {
        ball.SetHit(true);
        ball.SetSpeed(new Vector2(-1.5f * ball.GetSpeed().x, -1.5f * ball.GetSpeed().y));
        yield return new WaitForSeconds(0.5f);
        ball.SetHit(false);
    }

    IEnumerator Special()
    {
        isSpecial = false;
        Vector2 TempBallSpeed = ball.GetSpeed();
        ball.SetSpeed(Vector2.zero);
        ball.GetRb().gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        ball.transform.position = -attackPoint.position;
        TempBallSpeed *= 1.75f;
        ball.SetSpeed(TempBallSpeed);
        ball.GetRb().gameObject.SetActive(true);
        Debug.Log("Time's out");
    }
}

