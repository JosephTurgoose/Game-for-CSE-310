using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;
    public int ogHealth = 1;
    private int health;
    public float speed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        // Enemy HP scaling
        health = ogHealth * (gameManager.score / 5);
        if (health <= 0)
        {
            health = ogHealth;
        }
        if (health > 8)
        {
            health = 8;
        }
    }

    void Update()
    {
        // Death
        if (health <= 0)
        {
            Die();
            gameManager.Score();
        }
        // Linear travel towards the player
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health -= 1;
        }

        if (collision.gameObject.tag == "Player")
        {
            gameManager.Hurt();
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
