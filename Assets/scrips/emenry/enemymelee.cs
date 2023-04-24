using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymelee : MonoBehaviour
{
    public float movementSpeed = 5f;    // Speed at which the enemy moves towards the player
    public float stoppingDistance = 0f; // Distance at which the enemy stops moving towards the player
    public int damage=100;
    public float rechargeTime = 1.0f;
    public float speed = 1.0f;

    private takehealth playerHealth;
    private Transform playerTransform;   // Reference to the player's transform
    private float distanceThreshold = 2.0f;
    private bool canAttack = true;

    void Start() {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerHealth = player.GetComponent<takehealth>();
    }

    private void Update() {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // If the enemy is not within the stopping distance of the player, move towards the player
        if (distanceToPlayer > stoppingDistance) {
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }

        if (canAttack && distanceToPlayer <= distanceThreshold) {
            canAttack = false;
            StartCoroutine(ResetAttack());
            playerHealth.TakeDamage(damage);
        }
    }
    
    IEnumerator ResetAttack() {
        yield return new WaitForSeconds(rechargeTime);
        canAttack = true;
    }
}

