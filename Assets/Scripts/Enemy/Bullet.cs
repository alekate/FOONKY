using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10; // Adjust as needed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the collided GameObject
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            // If the PlayerHealth component exists, damage the player
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damageAmount, "TvFly");
            }
        }
        
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
}