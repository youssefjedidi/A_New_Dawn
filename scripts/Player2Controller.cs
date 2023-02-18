using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    //public float speed = 5f;
    public float jumpSpeed = 15f;
    private float direction = 0f;
    private Rigidbody2D player;
    //public Animator animator;
    //public bool Protected = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public bool DounleJump = false;

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

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);            
        }
        else if (Input.GetButtonDown("Jump") && !isTouchingGround && !  DounleJump)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed/2);
            DounleJump = true;          
        }


        if (Input.GetAxis("Vertical") < 0 && isTouchingGround && (direction < 0.1f || direction > -0.1f))
        {
            player.velocity = new Vector2(0, 0);
        }
        if(isTouchingGround)
        {
            DounleJump = false;  
        }
    }
    
}