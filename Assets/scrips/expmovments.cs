using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expmovments : MonoBehaviour
{
    public float speed = 5f; // the speed at which the object will move towards the player
    public float detectionRadius = 5f; // the radius in which the object will detect the player
    public float destroyRadius = 0f; // the radius at which the object will destroy itself upon hitting the player
    private Transform player; // reference to the player's transform
    private bool isFollowing = false; // flag indicating whether the object is currently following the player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // find the player's transform by searching for a GameObject with the "Player" tag
    }

    void Update()
    {
        // check if the distance between the object and the player is within the detection radius
        if (!isFollowing && Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            isFollowing = true;
        }

        // move towards the player if isFollowing is true
        if (isFollowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // check if the distance between the object and the player is within the destroy radius
            // if (Vector3.Distance(transform.position, player.position) < destroyRadius)
            // {
            //     Destroy(gameObject);
            // }
        }
    }
}
