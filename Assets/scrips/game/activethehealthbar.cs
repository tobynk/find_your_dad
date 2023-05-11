using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activethehealthbar : MonoBehaviour
{
    public GameObject healthbarsetactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sethealthbaractive()
    {
        healthbarsetactive.SetActive(true);
    }
}
