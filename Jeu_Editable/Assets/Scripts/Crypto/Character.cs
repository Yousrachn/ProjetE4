using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour


{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Logique de mouvement
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + dir * Time.fixedDeltaTime);
    }
}

