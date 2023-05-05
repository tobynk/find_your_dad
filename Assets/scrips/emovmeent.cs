using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emovmeent : MonoBehaviour
{
    public float speed = 40.0f;
    public int damage=200;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
