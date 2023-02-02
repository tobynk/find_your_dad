using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingmovements : MonoBehaviour
{
    public GameObject player;
    
    public float speed = 40.0f;
    
    // Start is called before the first frame update
    void Start()
    {
         Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
