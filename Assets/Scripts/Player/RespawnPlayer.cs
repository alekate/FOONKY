using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EasyTransition
{
    public class Respawn : MonoBehaviour
    {
        public TransitionSettings transition;

        private TransitionManager manager;

        private PlayerHealth playerHealth;

        public Transform spawnPoint;

        private bool isRespawning = false;

        private bool TeleportPlayer = false;

        private void Start()
        {
            manager = TransitionManager.Instance();
            playerHealth = GetComponentInParent<PlayerHealth>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R) && !isRespawning)
            {
                isRespawning = true;

                manager.Transition(transition, 0f);

                StartCoroutine(rWasPressed());
            }

            if (TeleportPlayer == true)
            {
                transform.position = spawnPoint.position;

                playerHealth.DamagePlayer(30, "Fall");

                isRespawning = false;

                TeleportPlayer = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Respawn") && !isRespawning)
            {
                StartCoroutine(RespawnPlayer());
            }

        }

        private IEnumerator RespawnPlayer()
        {
            manager.Transition(transition, 0f);

            yield return new WaitForSeconds(1f);

            TeleportPlayer = true;
        }

        private IEnumerator rWasPressed()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isRespawning = false;
        }
    }
}
