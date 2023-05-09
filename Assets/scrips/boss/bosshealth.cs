using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosshealth : MonoBehaviour
{
    public int health;
    public int maxhealth=100;
    public bool playerIsAlive = true;
    public int dropCount = 1;
    public GameObject healthbarsetactive;
    public bosshealthbar bosshealthbars;
    public activethehealthbar sethealthbar;

    // Start is called before the first frame update
   void Start()
    {
        sethealthbar = FindObjectOfType<activethehealthbar>();
        sethealthbar.sethealthbaractive();
        health = maxhealth;
        bosshealthbars = FindObjectOfType<bosshealthbar>();
        bosshealthbars.SetMaxHealth(maxhealth);
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
       bosshealthbars.SetHealth(health);
        Debug.Log(damage);
    }

    void Die()
    {
        Destroy(gameObject);
        playerIsAlive=false;
        
    }
}
