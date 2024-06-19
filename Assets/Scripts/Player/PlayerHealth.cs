using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthUI;
	[SerializeField] private TextMeshProUGUI armorUI;
    private PointSystem pointSystem;
    public Transform spawnPoint;

    public int maxHealth;
    public int health;

    public int maxArmor;
    public int armor;
    
    private void Awake() 
    {
        health = maxHealth;
        pointSystem = FindObjectOfType<PointSystem>();
    }
    
    async void Start()
    {
        await UnityServices.InitializeAsync();
        LevelStart();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Q))
        {
            DamagePlayer(30);
            Debug.Log("ouch");
        }*/

        healthUI.text = health.ToString();
		armorUI.text = armor.ToString();

    }

    public void DamagePlayer(int damage, string attacker)
    {
        if(armor > 0) //verifica si hay armor
        {

            if(armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage) //si el daño recibido es mayor a la amradura, romper la armadura y hacer el restante daño a la vida
            {
                int remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }

        }
        else
        {
            health -= damage;
        }

        if (health <= 0) // muelte pj
        {
            if (attacker == "Fall")
            {
                pointSystem.deathFall++;
            }
            pointSystem.deathCount++;

            Debug.Log("U Ded haha");
            GameOver(attacker);
            transform.position = spawnPoint.position;
            health = 100;
        }
        
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if(armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        if(armor > maxArmor)
        {
            armor = maxArmor;
        }
        
    }  

    private void GameOver(string who)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        var eventParams = new Dictionary<string, object>
        {
            { "deathCount", pointSystem.deathCount },
            { "deathFall", pointSystem.deathFall },
            { "enemyType", who },
            { "userLevel", currentSceneName }
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.CustomData("GameOverEvent", eventParams);
        AnalyticsService.Instance.Flush();
    }

    private void LevelStart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("nivel: " + currentSceneName);
        
        var eventParams = new Dictionary<string, object>
        {
            { "userLevel", currentSceneName }
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.CustomData("GameOverEvent", eventParams);
        AnalyticsService.Instance.Flush();
    }

}