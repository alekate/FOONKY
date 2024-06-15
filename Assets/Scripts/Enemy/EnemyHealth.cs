using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public int points = 10;
    public SpriteRenderer spriteRenderer;
    public EnemyAwareness enemyAwareness;
    public PointSystem pointSystem;

    private void Start() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyAwareness = GetComponentInChildren<EnemyAwareness>(); 
        pointSystem =  FindObjectOfType<PointSystem>(); 
    }

    public void TakeDamage (float amount, string gun)
    {
        health -= amount;
        spriteRenderer.color = Color.red;
        Invoke("ColorChange", 0.2f);
        enemyAwareness.isAggro = true;
        if (health <= 0f)
        {
            pointSystem.CountPoints(points, gun); 
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
