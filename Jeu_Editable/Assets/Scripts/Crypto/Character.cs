using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour


{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Logique de mouvement
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if(dir.x != 0 || dir.y != 0)
        {
            animator.SetFloat("X", dir.x);
            animator.SetFloat("Y", dir.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        rb.MovePosition(rb.position + dir * speed* Time.fixedDeltaTime);
    }
}

