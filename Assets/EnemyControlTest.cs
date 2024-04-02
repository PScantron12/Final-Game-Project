using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlTest : MonoBehaviour
{
    public float moveDistance = 3f; // Set the total distance to move
    public float moveSpeed = 2f; // Set the speed of movement

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Calculate the target position based on the direction of movement
        Vector3 destination = movingRight ? targetPosition : initialPosition;

        // Move towards the destination
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the destination
        if (transform.position == destination)
        {
            // If moving right and reached the target position, switch direction
            if (movingRight && destination == targetPosition)
            {
                movingRight = false;
            }
            // If moving left and reached the initial position, switch direction
            else if (!movingRight && destination == initialPosition)
            {
                movingRight = true;
            }
        }
    }
}
