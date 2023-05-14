using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfacing : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5f; // Speed at which the enemy rotates

    private void Update()
    {
        // Calculate the direction to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // Keep the enemy on the same plane as the player

        if (direction != Vector3.zero)
        {
            // Calculate the target rotation based on the direction to the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotate the enemy towards the player using Slerp for smooth rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        // Keep the enemy facing the player at all times
        transform.LookAt(player);
    }
}
