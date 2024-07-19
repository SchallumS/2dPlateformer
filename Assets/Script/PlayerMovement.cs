using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float move;
    public float speed;
    private bool is_on_ground = false;
    public float jump;
    private SpriteRenderer spriteRenderer;
    public Animator animator;

   void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
   }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("moveX", move);
        bool isMoving = !Mathf.Approximately(move, 0f);
        animator.SetBool("IsMoving", isMoving);

        // another way to move the sprite

        //rb.velocity = new Vector2(move * speed, rb.velocity.y);

        transform.Translate(move * speed * Time.deltaTime * Vector2.right);

        // Flip the sprite

        if (move < 0)
        {
            spriteRenderer.flipX = true; // left
        }
        else if (move > 0)
        {
            spriteRenderer.flipX = false; // right
        }

        if (Input.GetButtonDown("Jump") && is_on_ground)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            is_on_ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_on_ground = true;
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
        }
    }
}
