using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootingmovement : MonoBehaviour
{
    public float speed = 10f;
    private Transform player;
     public float detectionRange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float distance = direction.magnitude;
        if (distance <= detectionRange)
        {
           transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (distance >= detectionRange)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.position) < 0.5f)
        {
            // destroy the object if it has collided with the player
            Destroy(gameObject);
        }
        
        
    }
}
