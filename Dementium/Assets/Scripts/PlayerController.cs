using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    [SerializeField]
    public GameObject closedDoorL1;
    [SerializeField]
    public GameObject openDoorL1;

    private bool openUp;

    private Rigidbody2D rigidbody2d;
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        openDoorL1.gameObject.SetActive (false);
        closedDoorL1.gameObject.SetActive (true);
    }

    void Update()
    {
       var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

       if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2d.velocity.y) < 0.001f)
       {
           rigidbody2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
       }

       if (Input.GetKey(KeyCode.E))
       {
           if (openUp == true)
           {
                openDoorL1.gameObject.SetActive (true);
                closedDoorL1.gameObject.SetActive (false);
           }
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nearDoor1"))
        {
            openUp = true;
        }
    }
}