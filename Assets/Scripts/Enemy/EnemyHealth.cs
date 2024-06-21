using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50;
    public int points = 10;
    public SpriteRenderer spriteRenderer;
    public EnemyAwareness enemyAwareness;
    public PointSystem pointSystem;
    public Animator enemyAnim;
    public bool isBroken;
    


    private void Awake() 
    {
        
    }

    async void Start() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyAwareness = GetComponentInChildren<EnemyAwareness>(); 
        pointSystem =  FindObjectOfType<PointSystem>(); 
        await UnityServices.InitializeAsync();
        enemyAnim = GetComponentInChildren<Animator>();
        enemyAnim.SetFloat("Health", health);

    }

    public void TakeDamage (float amount, string gun)
    {
        health -= amount;
        spriteRenderer.color = Color.red;
        Invoke("ColorChange", 0.2f);
        enemyAwareness.isAggro = true;
        enemyAnim.SetFloat("Health", health);

       /* if (health <= 25f)
        {
            isBroken = true;
        }*/

        if (health <= 0)
        {
            pointSystem.CountPoints(points, gun); 
            WeaponEvent();
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


    private void WeaponEvent()
    {
        var eventParams = new Dictionary<string, object>
        {
            { "pistolKill", pointSystem.pistolKill },
            { "shotgunKill", pointSystem.shotgunKill },
            { "rifleKill", pointSystem.rifleKill },
            { "weaponTotal", "Pistol, Shotgun, Rifle" }
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.CustomData("GameOverEvent", eventParams);
        AnalyticsService.Instance.Flush();
    }
}
