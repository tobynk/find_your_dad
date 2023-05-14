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
    public float firingrate = 5;
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
        playercount=FindObjectsOfType<takehealth>().Length;
        if (playercount==0)
        {

        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= detectionRange)
        {
            timer += Time.deltaTime;

            // check if player is close enough and enough time has elapsed since last shot
            if (timer > firingrate)
            {
                // fire projectile and update lastFireTime
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Debug.Log("fire");
                timer = 0;
            }

        }
    }
}
