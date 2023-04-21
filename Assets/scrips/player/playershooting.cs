using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    public GameObject shootingE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var offset = new Vector3(Mathf.Cos(transform.eulerAngles.y), 0.0f, Mathf.Sin(transform.eulerAngles.y));
            Instantiate(shootingE, transform.position+ offset,transform.rotation);
        }
        
    }
}
