using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float PCmove = 0f;
    public Rigidbody2D rb;
    public Animator animator;
    bool facingRight = true;

    float horizontalMove = 0f;
    public Joystick joystick;

    Vector2 movement;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = joystick.Horizontal; Input.GetAxisRaw("Horizontal");
        movement.y = joystick.Vertical; Input.GetAxisRaw("Vertical");

        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }

        animator.SetFloat("Speed", movement.x);
        animator.SetFloat("Speed", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
