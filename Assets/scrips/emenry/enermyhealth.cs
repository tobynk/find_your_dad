using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyhealth : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public bool playerIsAlive = true;
    public healthbarem healthbarem;
    public int dropCount = 1;
    private level LevelScript;
    private int healthround;

    // Start is called before the first frame update
   void Start()
    {
        LevelScript = GameObject.FindObjectOfType<level>();
        healthround=maxhealth*LevelScript.levels;
        health = healthround; // initialize health to maximum value
        healthbarem.SetMaxHealth(maxhealth);
        Debug.Log("health"+health+"level"+LevelScript.levels);
        
    }
    void Update()
    {
        updatehealthbar();
    }
    public void updatehealthbar()
    {
        healthbarem.SetHealth(health);
        //Debug.Log("enemy health is"+health);
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
        Debug.Log("damage"+damage);
        Debug.Log("enemy health is"+health);
    }

    void Die()
    {

        Destroy(gameObject);
        playerIsAlive=false;
        
    }
}
