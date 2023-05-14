using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float spawnRange =10.0f;
    public int enenmycount;
    public int wavenumber=1;
    public int bossspawnwave=5;
    public int bigbossspawnwave=10;
    public List<GameObject> EnemyPrefab;
    public List<GameObject> bossPrefab;
    public GameObject bigbossPrefab;
    public bool bossbattle=false;
    public level level;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(wavenumber);
        level= FindObjectOfType<level>();
    }

    // Update is called once per frame
    void Update()
    {
        enenmycount=FindObjectsOfType<enermyhealth>().Length;

        if (enenmycount==0 && bossbattle == false)
        {
            wavenumber++;
            SpawnEnemyWave(wavenumber);
            level.roundup();
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
        if (wavenumber == bossspawnwave)
        {
            Instantiate(bossPrefab[0], GenerateSpawnPosition(), Quaternion.identity);
            Instantiate(bossPrefab[1], GenerateSpawnPosition(), Quaternion.identity);
            Instantiate(bossPrefab[2], GenerateSpawnPosition(), Quaternion.identity);
        }

        else if (wavenumber==bigbossspawnwave)
        {
            Instantiate(bigbossPrefab,GenerateSpawnPosition(), Quaternion.identity);
            bossbattle=true;
        }
        else
        {
            for(int i=0; i < enemiestospawn; i++)
        {
            int index = Random.Range(0,3);
            Instantiate(EnemyPrefab[index],GenerateSpawnPosition(), Quaternion.identity);
        }
        }
    }
}
