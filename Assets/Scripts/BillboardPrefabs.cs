using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardPrefabs : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform; 
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Calculate the rotation needed to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            // Apply the rotation to the billboard
            transform.rotation = lookRotation;
        }
    }
}