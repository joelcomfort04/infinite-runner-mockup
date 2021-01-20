using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 6;

    [SerializeField]
    private float jumpSpeed = 12;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject incomingObject = collision.gameObject;

        if (incomingObject.tag == ("Mushroom")) 
        {
            SetAllCollidersStatus(incomingObject);
            Destroy(incomingObject.GetComponent<Rigidbody2D>());
            incomingObject.GetComponent<Animator>().Play("Mushroom Death");
             
          
            
            

            
        }
        

    }


    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Terrain")) || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Enemy")))
        {
            isGrounded = true;
        }
        else { isGrounded = false; }

        if (!isGrounded) { animator.Play("Player Jump"); }

        if(Input.GetKey("d") || Input.GetKey("right")) 
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if (isGrounded) { animator.Play("Player Run"); }
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-1 * runSpeed, rb2d.velocity.y);
            if (isGrounded) { animator.Play("Player Run"); }
            spriteRenderer.flipX = true;
        }
        else
        {
            if (isGrounded) { animator.Play("Player Idle Norm"); }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
           
        }
        if(transform.position.y < -100f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        
    }

    public void SetAllCollidersStatus(GameObject obj)
    {
        foreach (Collider2D c in obj.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
    }

}
