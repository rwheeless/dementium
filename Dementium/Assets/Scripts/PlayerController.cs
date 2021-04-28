using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Animator animator;

    private Rigidbody2D rigidbody2d;

    private bool age1;
    private bool age2;
    private bool age3;

    Vector2 lookDirection = new Vector2(1,0);
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       Vector2 move = new Vector2(horizontal, vertical);

       if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

       if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2d.velocity.y) < 0.001f)
       {
           rigidbody2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
       }

       if (Input.GetKey(KeyCode.E))
       {
           if (age1 == true)
           {
               transform.position = new Vector3 (-30, 2, 0);
               age1 = false;
           }

           if (age2 == true)
           {
               transform.position = new Vector3 (-75, -5, 0);
               age2 = false;
           }

           if (age3 == true)
           {
               age3 = false;
           }
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nearBed1"))
        {
            age1 = true;
        }

        if (other.gameObject.CompareTag("nearBed2"))
        {
            age2 = true;
        }

        if (other.gameObject.CompareTag("nearBed3"))
        {
            age3 = true;
        }
    }
}