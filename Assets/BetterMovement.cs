using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BetterMovement : MonoBehaviour
{
    [SerializeField]
    float velocity;
    [SerializeField]
    bool isTopDown = false;
    Rigidbody2D rb;
    float verticalMove;
    
    float horizontalMove;
    [SerializeField]
    float verticalForce = 10.0f;
    bool isGrounded;

    private void Awake()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void moveCharacter()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * velocity;
        Vector2 tagetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        Vector2 m_velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, tagetVelocity, ref m_velocity, 0.05f);
    }
    bool wasPressed;
    void betterJump()
    {
        float fallMultiplayer = 2.5f;
        float lowMultiplayer = 2.0f;

        if(Input.GetButtonDown("Jump") && wasPressed)
        {
            rb.velocity = Vector2.up * verticalForce;
        }
        else
        {
            wasPressed = false;
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1)
                * Time.fixedDeltaTime;
            //rb = rb+

        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y *
                (lowMultiplayer - 1) * Time.fixedDeltaTime;
        }
    }
    // Use this for initialization
    void Start ()
    {
		
	}

    private void FixedUpdate()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        for(int i = 0; i< collider.Length;i++)
        {
            if(collider[i].gameObject.tag == "Ground")
            {
                wasPressed = true;
            }
        }
        betterJump();
        moveCharacter();

    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
