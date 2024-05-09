using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnim : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private float changeInterval = 0.25f; // Interval to switch sprites

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to switch the sprite
        if (timer >= changeInterval)
        {
            // Switch sprite
            spriteRenderer.sprite = spriteRenderer.sprite == sprite1 ? sprite2 : sprite1;

            // Reset the timer
            timer = 0f;
        }
    }
}