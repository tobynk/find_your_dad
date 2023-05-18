using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    public GameObject shootingmain;
    public KeyCode spawnKey = KeyCode.E; // The key to press to spawn the prefab
    public GameObject prefabToSpawn; // The prefab to spawn
    public KeyCode spawnQkey = KeyCode.Q;
    public bool powerup = false;
    public float powertimer = 10;
    public bool powerupready = false;
    public float timerforpowerup = 10;
    public int power=10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (powertimer <= 0)
        {
            powerupready = true;
            powertimer = 0;
        }
        else
        {
            powerupready = false;
            powertimer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            var offset = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0.0f, Mathf.Sin(transform.eulerAngles.y));
            Instantiate(shootingmain, transform.position + offset, transform.rotation);
          // Debug.Log("fire");
        }
        if (Input.GetKeyDown(spawnKey))
        {
            var eoffset = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0.0f, Mathf.Sin(transform.eulerAngles.y)) * 5f;
            Instantiate(prefabToSpawn, transform.position + eoffset, transform.rotation);
        }
        if (Input.GetKeyDown(spawnQkey) && powerupready == true)
        {
            powerup = true;
        }
        if (powerup == true)
        {
            if (timerforpowerup <= 0)
            {
                powerup = false;
                timerforpowerup = 10;
                powertimer = 10;
            }
            else
            {
                timerforpowerup -= Time.deltaTime;
            }
        }
    }
}

