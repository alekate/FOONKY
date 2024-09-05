using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyTransition
{
    public class Respawn : MonoBehaviour
    {
        public TransitionSettings transition;

        private TransitionManager manager;
        private PlayerHealth playerHealth;

        public Transform spawnPoint;

        private bool isRespawning = false; // Flag to track if the player is respawning

        private void Start()
        {
            manager = TransitionManager.Instance();
            playerHealth = GetComponentInParent<PlayerHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Respawn") && !isRespawning)
            {
                // Start the respawn process only if not already respawning
                isRespawning = true;

                // Trigger the transition with the correct TransitionSettings object
                manager.Transition(transition, 0f); // Use the transition object

                // Respawn the player after a delay to match the transition time
                StartCoroutine(RespawnPlayer());
            }
        }

        private IEnumerator RespawnPlayer()
        {
            yield return new WaitForSeconds(0.9f); // Match transition time delay
            transform.position = spawnPoint.position;
            playerHealth.DamagePlayer(30, "Fall");

            // Allow respawn again after it's completed
            isRespawning = false;
        }
    }
}
