using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperEnemy : MonoBehaviour
{
    public float jumpForce = 20.5f;
    public float pauseDuration = 1f; // Time to pause between jumps
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float nextJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextJumpTime = Time.time; // Initialize the first jump timing
    }

    void Update()
    {
        // Check if it's time to jump
        if (Time.time > nextJumpTime)
        {
            Jump();
            facingRight = !facingRight; // Change direction after jumping
            nextJumpTime = Time.time + pauseDuration; // Set the next jump time after pause
        }
    }

    private void Jump()
    {
        // Reset any existing motion
        rb.velocity = Vector2.zero;

        // Determine direction to jump
        Vector2 jumpDirection = facingRight ? Vector2.right : Vector2.left;

        // Apply jump force in the chosen direction along with an upward force
        rb.AddForce((Vector2.up + jumpDirection) * jumpForce, ForceMode2D.Impulse);
    }
}
