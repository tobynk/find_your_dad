using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshealth : MonoBehaviour
{
    public int health;
    public int maxhealth=100;
    public bool playerIsAlive = true;
    public healthbarem healthbarem;
    public int dropCount = 1;
    public GameObject healthbarsetactive;

    // Start is called before the first frame update
   void Start()
    {
        health = maxhealth; // initialize health to maximum value
        healthbarem.SetMaxHealth(maxhealth);
        healthbarsetactive.SetActive(true);
        
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
        Debug.Log(damage);
    }

    void Die()
    {
        Destroy(gameObject);
        playerIsAlive=false;
        
    }
}
