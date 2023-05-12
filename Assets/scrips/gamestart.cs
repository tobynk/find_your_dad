using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform
    public Transform objectTransform;  // Reference to the object's transform
    public float maxDistance = 10f;    // Maximum distance allowed between the player and the object
    public GameObject gamemanger;
    public KeyCode Key = KeyCode.R;

    private bool isObjectActive = true; // Flag to track if the object is currently active

    private void Update()
    {
        // Calculate the distance between the player and the object
        float distance = Vector3.Distance(playerTransform.position, objectTransform.position);

        // Check if the distance exceeds the maximum allowed distance
        if (distance > maxDistance && isObjectActive)
        {
            // Turn off the object
            objectTransform.gameObject.SetActive(false);
            isObjectActive = false;
        }
        else if (distance <= maxDistance && !isObjectActive)
        {
            // Turn on the object
            objectTransform.gameObject.SetActive(true);
            isObjectActive = true;
        }
        if (isObjectActive && Input.GetKeyDown(Key))
        {
            startthegame();
        }
    }

    void startthegame()
    {
        gamemanger.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
}
