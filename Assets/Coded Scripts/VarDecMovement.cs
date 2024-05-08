using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Horizontal speed (match or set relative to the player's speed)
    public float horizontalSpeed = 24.1f;

    // Vertical movement amplitude and frequency
    public float verticalAmplitude = 5.0f;
    public float verticalFrequency = 2.0f;

    // Start position for reference
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Horizontal movement
        float newX = startPosition.x + horizontalSpeed * Time.time;  // Keeps moving right

        // Vertical movement using sine wave for smooth oscillation
        float newY = startPosition.y + verticalAmplitude * Mathf.Sin(verticalFrequency * Time.time);

        // Update the boss position
        transform.position = new Vector3(newX, newY, startPosition.z);
    }
}

