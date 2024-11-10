using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class MeleeHealth : MonoBehaviour
{
    public float health;
    public int points;
    public PointSystem pointSystem;
    public SpriteRenderer spriteRenderer;
    private MaquinaEstados maquinaEstados;
    
    void Start()
    {
        pointSystem =  FindObjectOfType<PointSystem>(); 
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        maquinaEstados = GetComponent<MaquinaEstados>();
    }

    public void TakeDamage (float amount, string gun)
    {
        health -= amount;
        spriteRenderer.color = Color.red;
        Invoke("ColorChange", 0.2f);
        maquinaEstados.ActivarEstado(maquinaEstados.EstadoPersecucion);

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
