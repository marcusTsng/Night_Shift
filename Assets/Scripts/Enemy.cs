using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player;
    public float moveSpeed = 5f;
    public float attackRange = 0.5f;

    [Header("State")]
    [SerializeField] private bool isWatched = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Find player by tag if not assigned
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isWatched)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // Freeze completely when watched
            rb.velocity = Vector2.zero;
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Optional: Flip sprite to face player
        GetComponent<SpriteRenderer>().flipX = direction.x < 0;
    }

    // Called when the enemy enters the camera view
    private void OnBecameVisible()
    {
        isWatched = true;
    }

    // Called when the enemy leaves the camera view
    private void OnBecameInvisible()
    {
        isWatched = false;
    }
}

