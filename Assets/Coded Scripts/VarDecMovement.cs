
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarDecMovement : MonoBehaviour
{
    public Transform playerCamera; // Drag your main camera here through the inspector
    public float xOffset = 5f; // Distance from the camera on the X axis
    public float moveDistance = 3f; // Total distance to move up and down
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = new Vector3(playerCamera.position.x + xOffset, playerCamera.position.y, transform.position.z);
        transform.position = initialPosition;
    }

    void Update()
    {
        // Update initial position every frame to follow camera horizontally
        initialPosition.x = playerCamera.position.x + xOffset;

        // Calculate the target position based on the direction of movement
        Vector3 targetPosition = initialPosition + (movingUp ? Vector3.up * moveDistance : Vector3.down * moveDistance);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if VarDec has reached the target position
        if (transform.position == targetPosition)
        {
            movingUp = !movingUp; // Reverse the direction of movement
        }
    }
}
