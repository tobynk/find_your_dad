using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingmovements : MonoBehaviour
{
    public float speed = 3f;
    private Transform enemy;
    public float detectionRange = 1f;
    private Transform target; // Transform of the closest enemy
    private float currentLifetime; // Current lifetime of the bullet
    public LayerMask enemyLayer; // LayerMask for enemies
    public float maxDistance = 100.0f; // Maximum distance for seeking enemies
    public float straightBulletDistance = 20.0f; // Distance threshold for straight bullet
    public float destroyTime = 10f;
    private int enenmycount;
    public int damage=100;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update()
    {
        enenmycount = FindObjectsOfType<enermyhealth>().Length;

        if (enenmycount > 0)
        {
            FindClosestEnemy();
            if (enemy != null)
            {
                Vector3 direction = enemy.position - transform.position;
                direction.Normalize();

                if (Vector3.Distance(transform.position, enemy.position) > straightBulletDistance)
                {
                    // If the enemy is too far away, shoot in a straight line
                    transform.position += transform.forward * speed * Time.deltaTime;
                    Invoke("DestroyGameObject", destroyTime);
                }
                else
                {
                    // Otherwise, move towards the enemy
                    transform.position += direction * speed * Time.deltaTime;
                }

                if (Vector3.Distance(transform.position, enemy.position) < 0.5f)
                {
                    // destroy the object if it has collided with the player
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            // If there are no enemies, move the bullet in a straight line
            transform.position += transform.forward * speed * Time.deltaTime;
            Invoke("DestroyGameObject", destroyTime);
        }
}


    void FindClosestEnemy()
    {
        if (enenmycount==0)
        {

        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance, enemyLayer);
            float closestDistance = Mathf.Infinity;

            foreach (Collider collider in colliders)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    enemy = collider.transform;
                }
            }
        }
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        enermyhealth enemyHealth = other.gameObject.GetComponent<enermyhealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
