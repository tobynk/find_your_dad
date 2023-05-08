using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigbossspawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefab;
    public float spawnRadius = 5f;
    private float spawnRange =25.0f;
    private float spawnInterval = 25f;
    private float spawnTimer = 0f;
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange); 
        Vector3 randopos=new Vector3(spawnPosX,0,spawnPosZ);
        return randopos;
    }
    void SpawnObject()
    {
       int index = Random.Range(0,3);
        Instantiate(EnemyPrefab[index],GenerateSpawnPosition(), Quaternion.identity);
    }
}
