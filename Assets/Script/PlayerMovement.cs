using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float Health, MaxHealth;
    private float move;
    public float speed;
    private bool is_on_ground = false;
    public float jump;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool is_dead = false;

    [SerializeField]
    private HealthBarUI healthBar;
   void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = FindObjectOfType<HealthBarUI>();
        healthBar.SetMaxHealth(MaxHealth);
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

        /*if (Input.GetKeyDown("p"))
        {
            SetHealth(20f);
        }
        if (Input.GetKeyDown("l"))
        {
            SetHealth(-20f);
        }*/

        if (Health <= 0f)
        {
            is_dead = true;
        }
        if (is_dead)
        {
            Debug.Log("Player is dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_on_ground = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            SetHealth(-20f);
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            SetHealth(20f);
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0f, MaxHealth);
        healthBar.SetHealth(Health);
    }
}
