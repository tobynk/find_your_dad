using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymelee : MonoBehaviour
{
    public Transform playerTransform;   // Reference to the player's transform
    public float movementSpeed = 5f;    // Speed at which the enemy moves towards the player
    public float stoppingDistance = 0f; // Distance at which the enemy stops moving towards the player
    public int damage=100;

    private void Update() {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // If the enemy is not within the stopping distance of the player, move towards the player
        if (distanceToPlayer > stoppingDistance) {
            // Calculate the direction in which to move towards the player
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Move towards the player in the calculated direction at the set movement speed
            transform.position += directionToPlayer * movementSpeed * Time.deltaTime;
        }
    }
}

