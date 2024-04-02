using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlTestUpDown : MonoBehaviour
{
    public float moveDistance = 3f; // Set the total distance to move
    public float moveSpeed = 2f; // Set the speed of movement

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up * moveDistance; // Move up instead of right
    }

    void Update()
    {
        // Calculate the target position based on the direction of movement
        Vector3 destination = movingUp ? targetPosition : initialPosition;

        // Move towards the destination
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the destination
        if (transform.position == destination)
        {
            // If moving up and reached the target position, switch direction
            if (movingUp && destination == targetPosition)
            {
                movingUp = false;
            }
            // If moving down and reached the initial position, switch direction
            else if (!movingUp && destination == initialPosition)
            {
                movingUp = true;
            }
        }
    }
}
