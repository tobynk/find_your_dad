using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caerma : MonoBehaviour
{
    public GameObject player;
    private Vector3 Offset = new Vector3(0, 2, -7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + Offset;
    }
}
