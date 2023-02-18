using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    public Animator animator;
    public bool Protected = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    private bool FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            animator.SetFloat("speed" , speed);

            player.velocity = new Vector2(direction * speed, player.velocity.y);
            if (!FacingRight)
            Flip();
        }
        else if (direction < 0f)
        {
            animator.SetFloat("speed" , speed);
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            if (FacingRight)
            Flip();
        }
        else
        {
            animator.SetFloat("speed" , 0);
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);            
        }


        if (Input.GetAxis("Vertical") < 0 && isTouchingGround && (direction < 0.1f || direction > -0.1f))
        {
            player.velocity = new Vector2(0, 0);
            animator.SetFloat("inverse" , 1);
            animator.SetBool("protected" , true);
            Protected = true;
        }
        else
        {
            animator.SetBool("protected" , false);
            animator.SetFloat("inverse" , -1);
            Protected = false;
        }
        
        if(!isTouchingGround)
        {
            animator.SetBool("jump" , true);
        }
        else
        {
            Invoke("notJump", 0.2f);
        }
    }
    private void notJump()
    {
        animator.SetBool("jump" , false);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


