using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float maxSpeed = 10f;
    
    public float jumpSpeed = 5f;
    public float horizontalDrag = 2f;
    public Vector2 groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public string horizontalInput;
    public string jumpInput;
    public string crouchInput;
    public float originalHeight;
    public float crouchHeight;

    public AudioSource jumpSFX;

    public Animator anim;

    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private float movement;
    private bool jump;
    private bool crouch;
    private bool isGrounded;
    private bool isFlipped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsCrouchHold", false);
        anim.SetBool("IsCrouchRelease", false);
    }
       
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw(horizontalInput) * speed;
        
        if(Input.GetButtonDown(jumpInput) && isGrounded)
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown(crouchInput) && isGrounded)
        {
            crouch = true;
        }
        if (Input.GetButtonUp(crouchInput))
        {
            crouch = false;
        }
        // Grounded Check
        Collider2D collider = Physics2D.OverlapCircle(rb.position + groundCheckPosition, groundCheckRadius, whatIsGround);
        if (collider != null)
        {   
            if (rb.velocity.y < 0f)
            {
                isGrounded = true;
                anim.SetBool("IsJumping", false);
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float t = rb.velocity.x / maxSpeed;

        float lerp = 0f;

        if (t >= 0f)
            lerp = Mathf.Lerp(maxSpeed, 0f, t);
        else if (t < 0f)
            lerp = Mathf.Lerp(maxSpeed, 0f, Mathf.Abs(t));

        Vector2 force = new Vector2(movement * lerp * speed * Time.fixedDeltaTime, 0f);
        Vector2 drag = new Vector2(-rb.velocity.x * horizontalDrag * Time.fixedDeltaTime, 0f);

        rb.AddForce(force, ForceMode2D.Force);
        rb.AddForce(drag, ForceMode2D.Force);

        if (movement >= .1f && isFlipped)
        {
            Vector2 flipScale = new Vector2(-1f, 1f);         
            isFlipped = false;
        }
        else if (movement <= -.1f && !isFlipped)
        {
            Vector2 flipScale = new Vector2(-1f, 1f);
            isFlipped = true;
        }

        if (jump == true)
        {
            Vector2 vel = rb.velocity;
            jumpSFX.Play();
            vel.y = jumpSpeed;
            rb.velocity = vel;
            jump = false;
            isGrounded = false;
        }

        if(crouch==true)
        {
            cc.radius = crouchHeight;
            anim.SetBool("IsCrouchHold", true);
            anim.SetBool("IsCrouchRelease", false);
        }
        if(crouch==false)
        {
            cc.radius = originalHeight;
            anim.SetBool("IsCrouchHold", false);
            anim.SetBool("IsCrouchRelease", true);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + groundCheckPosition, groundCheckRadius);
    }

}
