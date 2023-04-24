using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymelee : MonoBehaviour
{
    public Transform playerTransform;   // Reference to the player's transform
    public float speed = 5f;    // Speed at which the enemy moves towards the player
    public float stoppingDistance = 0f; // Distance at which the enemy stops moving towards the player
    public int damage=100;
    private Transform player;
    void Start()
    {
        // find player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Debug.Log(distanceToPlayer);

        // If the enemy is not within the stopping distance of the player, move towards the player
        if (distanceToPlayer > stoppingDistance) {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

