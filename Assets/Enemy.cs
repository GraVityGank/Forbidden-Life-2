using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //public Animator animator;
    public int MaxHealth = 100;
    private Rigidbody2D rb;
    private Vector3 movement;
    public Transform Player;
    public float moveSpeed = 5f;
    int currentHealth;
    bool facingRight = true;

    void Start()
    {
        currentHealth = MaxHealth;
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Monster Death");
        //animator.SetTrigger("break");

        if (currentHealth <= 0)
        {
            Score.scoreValue += 1;
            Die();
        }
        else if (currentHealth <= 1)
        {
            Score.scoreValue += 5;
            Die();
        }
        else if (currentHealth <= 2)
        {
            Score.scoreValue += 10;
            Die();
        }
    }

    void Update()
    {
        Vector3 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }

    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
