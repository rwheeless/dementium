using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private int count;

    public int health { get { return currentHealth; }}
    int currentHealth;

    private Animator animator;

    private Rigidbody2D rigidbody2d;

    private bool age1;
    private bool age2;
    private bool age3;

    private bool level2;
    private bool level3;

    public Text countText;
    public Text loseText;

    [SerializeField]
    GameObject inter1;
    [SerializeField]
    GameObject inter2;
    [SerializeField]
    GameObject inter3;



    Vector2 lookDirection = new Vector2(1,0);
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        count = 3;
        SetCountText ();

        inter1.gameObject.SetActive (false);
        inter2.gameObject.SetActive (false);
        inter3.gameObject.SetActive (false);
    }

    void Update()
    {
       var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");

       Vector2 move = new Vector2(horizontal, vertical);

        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Dementium");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }

       if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

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
               transform.position = new Vector3 (17, 20, 0);
               inter1.gameObject.SetActive (true);
               level2 = true;
               age1 = false;
           }

           if (age2 == true)
           {
               transform.position = new Vector3 (17, 20, 0);
               inter2.gameObject.SetActive (true);
               level3 = true;
               age2 = false;
           }

           if (age3 == true)
           {
               transform.position = new Vector3 (17, 20, 0);
               inter3.gameObject.SetActive (true);
               age3 = false;
           }
       }

       if (Input.GetKey(KeyCode.R))
       {
           if (level2 == true)
           {
               transform.position = new Vector3 (-31, 1, 0);
               inter1.gameObject.SetActive (false);
               level2 = false;
           }

           if (level3 == true)
           {
               transform.position = new Vector3 (-75, -5, 0);
               inter2.gameObject.SetActive (false);
               level3 = false;
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

        if(other.gameObject.CompareTag("Ghost"))
        {
            count = count - 1;
            SetCountText ();
        }

        if(other.gameObject.CompareTag("DEATH"))
        {
            count = 0;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Health: " + count.ToString ();

        if (count == 0)
        {
            loseText.text = "GAME OVER. Press L to Restart.";
            count = 0;
        }
    }


}