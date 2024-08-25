using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10;
    public int points = 10;
    public SpriteRenderer spriteRenderer;
    public EnemyAwareness enemyAwareness;
    public PointSystem pointSystem;
    public Animator enemyAnim;
    public bool isBroken;

    async void Start() 
    {
        enemyAnim = GetComponentInChildren<Animator>();
        enemyAnim.SetFloat("Health", health);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyAwareness = GetComponentInChildren<EnemyAwareness>(); 
        pointSystem =  FindObjectOfType<PointSystem>(); 

        //await UnityServices.InitializeAsync();
        /*
        if(UnityServices.State == ServicesInitializationState.Initialized)
        {
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("AnalyticsCollection");
        }*/

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
        Debug.Log("WeaponEvent");

        CustomEvent WeaponEvent = new CustomEvent("WeaponEvent")
        {
            { "pistolKill", pointSystem.pistolKill },
            { "shotgunKill", pointSystem.shotgunKill },
            { "rifleKill", pointSystem.rifleKill },
            { "weaponTotal", "Pistol, Shotgun, Rifle"} //Actualizar para cuando implementemos tienda
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.RecordEvent(WeaponEvent);
        AnalyticsService.Instance.Flush();
    }

}
