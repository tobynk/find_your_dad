using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovment : MonoBehaviour
{
    public Transform player;
    public float teleportDistance = 10.0f;
    public float minTeleportInterval = 1.0f;
    public float maxTeleportInterval = 10.0f;

    private float teleportTimer = 0.0f;
    private float teleportInterval;

    void Start()
    {
        // Set the initial teleport interval
        SetTeleportInterval();
    }

    void Update()
    {
        // Check if it's time to teleport
        teleportTimer += Time.deltaTime;
        if (teleportTimer >= teleportInterval)
        {
            Teleport();
            teleportTimer = 0.0f;
            // Set a new random teleport interval
            SetTeleportInterval();
        }
    }

    void SetTeleportInterval()
    {
        // Set a random teleport interval between minTeleportInterval and maxTeleportInterval
        teleportInterval = Random.Range(minTeleportInterval, maxTeleportInterval);
    }

    void Teleport()
    {
        // Teleport the enemy to a random position around the player
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 offset = new Vector3(randomDirection.x, 0f, randomDirection.y) * teleportDistance;
        transform.position = player.position + offset;
    }
}
