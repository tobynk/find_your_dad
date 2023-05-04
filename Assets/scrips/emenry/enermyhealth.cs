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
    public int dropCount = 1;

    // Start is called before the first frame update
   void Start()
    {
        health = maxhealth; // initialize health to maximum value
        healthbarem.SetMaxHealth(maxhealth);
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // subtract damage from current health
        if (health <= 0)
        {
            Die(); // if health reaches zero or below, call Die() function
        }
        healthbarem.SetHealth(health);
    }

    void Die()
    {
        Instantiate(objectToDrop);
        Destroy(gameObject);
        playerIsAlive=false;
        
    }
}
