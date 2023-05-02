using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossspawner : MonoBehaviour
{
   public GameObject prefabToSpawn;
    public float spawnRadius = 5f;

    private float spawnInterval = 1f;
    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = transform.position + new Vector3(randomDirection.x, 0f, randomDirection.y) * spawnRadius;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
