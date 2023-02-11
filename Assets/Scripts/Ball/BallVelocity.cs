using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed  = new Vector2(3,5);
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
