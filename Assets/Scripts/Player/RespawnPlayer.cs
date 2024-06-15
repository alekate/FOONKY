using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public Transform spawnPoint;

    private void Start()
    {
        // Initialize playerHealth by finding the PlayerHealth component in the parent or elsewhere in the hierarchy
        playerHealth = GetComponentInParent<PlayerHealth>();

        // If you want to find PlayerHealth from another object, you can do so:
        // playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            transform.position = spawnPoint.position;

            // Call the DamagePlayer method to decrease the player's health
            playerHealth.DamagePlayer(30); // Assuming you want to deal 30 damage
        }    
    }
}