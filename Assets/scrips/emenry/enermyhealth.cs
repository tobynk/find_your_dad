using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyhealth : MonoBehaviour
{
    public int health;
    public int maxhealth=100;
    public bool playerIsAlive = true;
    public healthbarem healthbarem;
     public GameObject objectToDrop;
    public Transform enemyPosition;
    public int dropCount = 1;

    // Start is called before the first frame update
   void Start()
    {
        health = maxhealth; // initialize health to maximum value
        healthbarem.SetMaxHealth(maxhealth);
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mainat") // check if collided object has the "Enemy" tag
        {
            TakeDamage(10); // reduce health by 10 points
            Debug.Log("fuck u");
            healthbarem.SetHealth(health);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // subtract damage from current health
        if (health <= 0)
        {
            Die(); // if health reaches zero or below, call Die() function
        }
    }

    void Die()
    {
        Destroy(gameObject);
        playerIsAlive=false;
        DropObjects();
    }
    private void DropObjects()
    {
        if (objectToDrop != null && enemyPosition != null)
        {
            for (int i = 0; i < dropCount; i++)
            {
                Vector3 spawnPosition = enemyPosition.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                Instantiate(objectToDrop, spawnPosition, Quaternion.identity);
            }
        }
    }
}
