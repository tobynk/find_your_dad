using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootingmovement : MonoBehaviour
{
    public float speed = 10f;
    private Transform player;
    public float detectionRange = 1f;
    public int takingshit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
   void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.position) < 0.5f)
        {
            // destroy the object if it has collided with the player
            Destroy(gameObject);
        }
        
        
    }
}