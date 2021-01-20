using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehavior : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    bool isGoingRight = true;
    bool isGoingLeft = false;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform leftCheck;

    [SerializeField]
    Transform rightCheck;

    [SerializeField]
    private float runSpeed = 8;

  


   
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    //collision between other gameobjects on layer 'Enemy'

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isGoingRight = !isGoingRight;
            isGoingLeft = !isGoingLeft;
        }

    }


    //movement logic

    private void FixedUpdate()
    {
        if (rb2d != null) 
        { 
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Terrain")))
            {
                isGrounded = true;
            }
            else { isGrounded = false; }

            if (Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Terrain")) 
                || Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Player"))) 
            {
                isGoingRight = false;
                isGoingLeft = true;
            }

            if (Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Terrain")) 
                || Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Player"))) 
            {
                isGoingRight = true;
                isGoingLeft = false;
            }

            if (isGoingRight)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                if (isGrounded) { animator.Play("Mushroom Run"); }
                spriteRenderer.flipX = false;
            }
            if (isGoingLeft)
            {
                rb2d.velocity = new Vector2(-1 * runSpeed, rb2d.velocity.y);
                if (isGrounded) { animator.Play("Mushroom Run"); }
                spriteRenderer.flipX = true;
             }

        }



    }

}

