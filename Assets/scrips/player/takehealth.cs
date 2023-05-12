using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class takehealth : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public bool playerIsAlive = true;
    public healthbar healthBar;
    public TextMeshProUGUI healthtext;
    public level level;


    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth; // initialize health to maximum value
        healthBar.SetMaxHealth(maxhealth);
        level= GetComponent<level>();
    }
    void Update()
    {
        
    }
    
    public void addmoreheatlh()
    {
        level= GetComponent<level>();
        maxhealth=level.levels*1000;
        health=maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("enemy"))
    //     {
    //         // get the damage value from the enemy melee script
    //         int damage = other.gameObject.GetComponent<enemymelee>().damage;
    //         TakeDamage(damage);
    //         Debug.Log("dieeeeee");
    //     }
    //     else if (other.gameObject.CompareTag("bullets"))
    //     {
    //         // get the damage value from the bullet script
    //         int damage = other.gameObject.GetComponent<enemyshootingmovement>().damage;
    //         TakeDamage(damage);
    //         Debug.Log("you are taking"+damage);
    //         Destroy(other.gameObject);
    //     }
    // } 


    public void TakeDamage(int damage)
    {
        health -= damage; // subtract damage from current health
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die(); // if health reaches zero or below, call Die() function
        }
    }

    void Die()
    {
        Destroy(gameObject);
        playerIsAlive = false;
    }
}

