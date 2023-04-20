using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Vector2 speed;
    private Rigidbody2D rb;
    private bool isHit = false;

    public AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(-5, 3);
    }


    void Update()
    {
        rb.velocity = speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(other.gameObject);
        else //obstacle
        {
            audioSource.PlayOneShot(sound);

            Vector2 hit = other.contacts[0].normal;
            float angle = Vector2.Angle(hit, Vector2.up);

            if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180))
            { // top ||bottom
                speed.y *= -1;
            }
            else if (Mathf.Approximately(angle, 90))
            { //sides
                speed.x *= -1;
            }
            else
            { //other angles
                Vector2 dir = Vector2.Reflect(speed.normalized, hit);
                speed = dir * speed.magnitude;
            }
        }
    }
    public bool GetHit()
    {
        return isHit;
    }
    public void SetHit(bool hit)
    {
        isHit = hit;
    }

    public Vector2 GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(Vector2 spd)
    {
        speed = spd;
    }

    public Rigidbody2D GetRb()
    {
        return rb;
    }

    public void SetRb(Rigidbody2D Nrb)
    {
        rb = Nrb;
    }

}
