using UnityEngine;

public class JumperEnemy : MonoBehaviour
{
    public float jumpHeight = 3f; // Height of the jump
    public float jumpDuration = 1f; // Time to reach maximum height and return to start
    public float idleDuration = 3f; // Time to wait before jumping again
    public Sprite idleSprite;
    public Sprite jumpingSprite;

    private SpriteRenderer spriteRenderer;
    private Vector3 initialPosition;
    private Vector3 peakPosition;
    private float stateTimer;
    private bool isJumping;
    private bool ascending; // Determines if the jumper is going up or down

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        peakPosition = initialPosition + Vector3.up * jumpHeight;
        spriteRenderer.sprite = idleSprite; // Start in idle state
        isJumping = false;
        ascending = true; // Start by going up
        stateTimer = idleDuration; // Start with an idle timer
    }

    void Update()
    {
        stateTimer -= Time.deltaTime;

        if (!isJumping && stateTimer <= 0f)
        {
            // Start the jump
            isJumping = true;
            ascending = true;
            spriteRenderer.sprite = jumpingSprite;
            stateTimer = jumpDuration / 2; // Timer for ascending
        }
        else if (isJumping)
        {
            if (ascending)
            {
                // Move upwards
                transform.position = Vector3.MoveTowards(transform.position, peakPosition, 2 * jumpHeight / jumpDuration * Time.deltaTime);
                // Check if reached the peak
                if (transform.position == peakPosition)
                {
                    ascending = false; // Start descending
                }
            }
            else
            {
                // Move downwards
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, 2 * jumpHeight / jumpDuration * Time.deltaTime);
                // Check if reached the initial position
                if (transform.position == initialPosition)
                {
                    // End the jump and reset to idle state
                    isJumping = false;
                    spriteRenderer.sprite = idleSprite;
                    stateTimer = idleDuration; // Reset the idle timer after landing
                }
            }
        }
    }
}
