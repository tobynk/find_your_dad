using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activethehealthbar : MonoBehaviour
{
    public GameObject healthbarsetactive;
    public GameObject stamabar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stamabarsetactive()
    {
        stamabar.SetActive(true);
        Debug.Log("it works");
    }
    public void stamabarsetdeactive()
    {
        stamabar.SetActive(false);
    }
    public void sethealthbaractive()
    {
        healthbarsetactive.SetActive(true);
    }
}
