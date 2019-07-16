using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public float verticalForceMagnitude;
    Rigidbody2D rb;
    bool isGrounded;
    int numJumps;
    const int LIMITJUMPS = 1;
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
         isGrounded = true;
	}


    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * verticalForceMagnitude);
            numJumps++;
            if (numJumps == LIMITJUMPS)
            {
                isGrounded = false;
            }

        }
        
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector2.right * velocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * velocity;
        }
        
    }

    void Update ()
    {
        Vector2 targetVelocity;
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
      if (collision.tag == "Ground")
        {
            isGrounded = true;
            numJumps = 0;
        }
    }
}
