using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class takehealth : MonoBehaviour
{
    public int health;
    public int maxhealth=1000;
    public bool playerIsAlive = true;
    public healthbar healthBar;
    public TextMeshProUGUI healthtext;
    private enemyshootingmovement taking;
    
    
    // Start is called before the first frame update
   void Start()
    {
        health = maxhealth; // initialize health to maximum value
        healthBar.SetMaxHealth(maxhealth);
        Updatehealth();
    }
    
    void OnTriggerEnter(Collider other)
    {   
        enemyshootingmovement damage = other.GetComponent<enemyshootingmovement>();
        if (other.gameObject.tag == "bullets" ) // check if collided object has the "bullets" tag and the enemyshootingmovement component
        {
            TakeDamage(damage.takingshit); // reduce health by the bullet's damage
            Debug.Log(damage.takingshit);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage; // subtract damage from current health
        healthBar.SetHealth(health);
        Updatehealth();
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
    public void Updatehealth()
    {
        healthtext.text=health+"/"+maxhealth;
    }
}

