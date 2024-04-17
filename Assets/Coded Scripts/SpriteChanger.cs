using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteSwitcher : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite jumpingSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Check if the character's y velocity is positive (moving upwards)
        if (rb.velocity.y > 0)
        {
            // Set the jumping sprite if it's not already set
            if (!isJumping)
            {
                spriteRenderer.sprite = jumpingSprite;
                isJumping = true;
            }
        }
        else
        {
            // Set the default sprite if it's not already set
            if (isJumping)
            {
                spriteRenderer.sprite = defaultSprite;
                isJumping = false;
            }
        }
    }
}