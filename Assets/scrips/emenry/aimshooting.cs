using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimshooting : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public float shootingCooldown = 1f;
    private float shootingTimer = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingCooldown)
        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Add code to set bullet velocity or apply force to the rigidbody
    }
}
