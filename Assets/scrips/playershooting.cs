using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    private Vector3 Offset = new Vector3(0, 0, 1);
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
            Instantiate(shootingE, transform.position+ Offset,transform.rotation);
        }
        
    }
}
