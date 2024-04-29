using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    public Animator animator;

    //inputs

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si on avance
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animator.SetBool("IsRunning", true);
            }
        }
        // Si on recule
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -walkSpeed / 2 * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        // Rotation à gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        // Rotation à droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
