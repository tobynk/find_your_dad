using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSHOOTING : MonoBehaviour
{
    public GameObject projectilePrefab;  // the object to fire
    public float fireInterval = 20f;     // time between shots
    public float detectionRange = 30f;   // distance at which player is considered "close"
    private Transform player;            // reference to player's transform
    private float lastFireTime;          // time when enemy last fired
    public float timer = 0;
    public int firingrate;
    public float distanceToPlayer;
    public int playercount;

    void Start()
    {
        // find player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        firingrate = Random.Range(1, 11);
    }

    void Update()
    {
        // calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        timer += Time.deltaTime;

        // check if player is close enough and enough time has elapsed since last shot
        if (timer > firingrate && player != null)
        {
            // fire projectile and update lastFireTime
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            timer = 0;
            firingrate = Random.Range(1, 11); // set new firing rate
        }
    }
}
