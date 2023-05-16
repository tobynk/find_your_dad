using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    public GameObject shootingmain;
    public KeyCode spawnKey = KeyCode.E; // The key to press to spawn the prefab
    public GameObject prefabToSpawn; // The prefab to spawn
    public KeyCode spawnQkey = KeyCode.Q; 
    public bool powerup=false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var offset = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0.0f, Mathf.Sin(transform.eulerAngles.y));
            Instantiate(shootingmain, transform.position+ offset,transform.rotation);
        }
       if (Input.GetKeyDown(spawnKey))
        {
          var eoffset = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0.0f, Mathf.Sin(transform.eulerAngles.y)) * 5f;
            Instantiate(prefabToSpawn, transform.position+ eoffset,transform.rotation);
        }
        if (Input.GetKeyDown(spawnQkey))
        {
          powerup=true;
        }
    }

}
