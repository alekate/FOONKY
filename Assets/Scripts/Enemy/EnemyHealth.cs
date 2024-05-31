using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        spriteRenderer.color = Color.red;
        Invoke("ColorChange", 0.2f);
        if (health <= 0f)
        {
            Die();
        }
    
    }

    void Die ()
    {
        Destroy(gameObject);
    }

    public void ColorChange()
    {
        spriteRenderer.color = Color.white;
    }
}
