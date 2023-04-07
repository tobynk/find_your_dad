using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyhealth : MonoBehaviour
{
    public int health;
    public int maxhealth=100;
    public bool playerIsAlive = true;

    // Start is called before the first frame update
   void Start()
    {
        health = maxhealth; // initialize health to maximum value
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mainat") // check if collided object has the "Enemy" tag
        {
            TakeDamage(10); // reduce health by 10 points
            Debug.Log("fuck u");
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
    }
}
