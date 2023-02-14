using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSHOOTING : MonoBehaviour
{
    public GameObject shots;
    public bool near;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(shots, transform.position, transform.rotation);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playeracctacker"))
        {
            near = true;
        }
    }
}