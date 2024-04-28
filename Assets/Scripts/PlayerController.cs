using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float moveX;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool isJumping;
    public Animator anim;
    bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed, rb2d.velocity.y);
        
        if (moveX >= 0.1f || moveX <= -0.1f)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }

        if (moveX <= -0.1f && facingRight)
        {
            flip();
        }
        if (moveX >= 0.1f && !facingRight)
        {
            flip();
        }
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //Check the collision of the block. *Enter
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = false;
        }
    }
 
    private void OnCollisionExit2D(Collision2D collision) //*Exit
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }

        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = true;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
