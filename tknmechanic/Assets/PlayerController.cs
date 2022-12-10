using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool facingRight = true;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;


    public float MoveSpeed = 1f;
    public float jumpSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (rb.velocity.x<0 && facingRight)
        {
            flipFace();
        }
        else if(rb.velocity.x>0 && !facingRight)
        {
            flipFace();
        }
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            Jump();
        }
    }
    void HorizontalMove()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
    }
    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 transLocale = transform.localScale;
        transLocale.x *= -1;
        transform.localScale = transLocale;
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpSpeed));
    }
    void OnGroundCheck()
    {
       isGrounded= Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }
}
