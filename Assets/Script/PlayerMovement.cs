using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float move;
    public float speed;

    public float jump;

    //private bool isflipped = false;
    public Animator animator;
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("moveX", move);
        bool isMoving = !Mathf.Approximately(move, 0f);
        /*if (move < 0)
        {
            isflipped = true
            //transform.localeScale =  new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } else {
            //transform.localeScale =  new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isflipped = false;
        }*/
        animator.SetBool("IsMoving", isMoving);
        //if (isflipped == true)
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
