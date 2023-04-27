using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovment : MonoBehaviour
{
    public Transform player;
    public float teleportDistance = 10.0f;
    public float teleportInterval = 10.0f;

    private float teleportTimer = 0.0f;

    void Update()
    {
        // Check if it's time to teleport
        teleportTimer += Time.deltaTime;
        if (teleportTimer >= teleportInterval)
        {
            Teleport();
            teleportTimer = 0.0f;
        }
    }

    void Teleport()
    {
        // Teleport the enemy to a random position around the player
        Vector3 offset = Random.insideUnitSphere * teleportDistance;
        offset.y = 0.0f; // Keep the enemy on the same level as the player
        transform.position = player.position + offset;
    }
}
