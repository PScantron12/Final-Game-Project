using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float horizontalSpeed = 24.1f;
    public float verticalAmplitude = 5.0f;
    public float verticalFrequency = 2.0f;

    private Vector3 startPosition;
    private float localTimer; // A timer that resets with the scene

    void Start()
    {
        startPosition = transform.position;
        localTimer = 0f;  // Initialize timer
    }

    void Update()
    {
        localTimer += Time.deltaTime; // Increment local timer by the time passed since last frame

        // Horizontal movement
        float newX = startPosition.x + horizontalSpeed * localTimer;  // Use localTimer instead of Time.time

        // Vertical movement using sine wave for smooth oscillation
        float newY = startPosition.y + verticalAmplitude * Mathf.Sin(verticalFrequency * localTimer);

        // Update the boss position
        transform.position = new Vector3(newX, newY, startPosition.z);
    }
}


