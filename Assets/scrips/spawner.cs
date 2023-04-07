using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float spawnRange =9.0f;
    public int enenmycount;
    public int wavenumber=1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wavenumber);
    }

    // Update is called once per frame
    void Update()
    {
        enenmycount=FindObjectsOfType<enermyhealth>().Length;

        if (enenmycount==0)
        {
            wavenumber++;
            SpawnEnemyWave(wavenumber);
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange); 
        Vector3 randopos=new Vector3(spawnPosX,0,spawnPosZ);
        return randopos;
    }
    
    void SpawnEnemyWave(int enemiestospawn)
    {
        for(int i=0; i < enemiestospawn; i++)
        {
            Instantiate(EnemyPrefab,GenerateSpawnPosition(),EnemyPrefab.transform.rotation);
        }
    }
}
