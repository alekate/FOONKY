using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine.UI;

namespace EasyTransition
{
    public class PlayerHealth : MonoBehaviour
    {
        public TransitionSettings transition;

        private TransitionManager manager;

        private PointSystem pointSystem;

        public Transform spawnPoint;

        public int maxHealth;
        public int health = 100;
        public bool playerDead = false;

        public int maxArmor;
        public int armor = 0;

        public LifeSistemSlider lifesistemslider;
        public ArmorSistemSlider armorsistemslider;

        public bool hit = false;
        public GameObject playerHurtGameObject;

        private void Awake() 
        {
            health = maxHealth;
            pointSystem = FindObjectOfType<PointSystem>();
        }
    
        async void Start()
        {
            await UnityServices.InitializeAsync();
            LevelStart();
            lifesistemslider.SetMaxHealth(maxHealth);
            armorsistemslider.SetArmor(armor);

            playerHurtGameObject.SetActive(false);

            manager = TransitionManager.Instance();
        }

        void FixedUpdate()
        {
            if (playerDead == true)
            {
                transform.position = spawnPoint.position;
            
                health = 100;

                lifesistemslider.SetHealth(health);
                armorsistemslider.SetArmor(armor);

                playerDead = false; 
            }
        }

        private IEnumerator RespawnPlayer()
        {
            manager.Transition(transition, 0f);

            yield return new WaitForSeconds(1f);

            playerDead = true;
        }

        public void LoseHealthBar()
        {
            lifesistemslider.SetHealth(health);
        }

        public void LoseArmorhBar()
        {
            armorsistemslider.SetArmor(armor);
        }
    
        public void DamagePlayer(int damage, string attacker)
        {
            ShowDamageFeedback();

            if (armor > 0) //verifica si hay armor
            {

                if(armor >= damage)
                {
                    armor -= damage;
                    armorsistemslider.SetArmor(armor);
                }
                else if (armor < damage) //si el daño recibido es mayor a la amradura, romper la armadura y hacer el restante daño a la vida
                {
                    int remainingDamage;

                    remainingDamage = damage - armor;

                    armor = 0;

                    health -= remainingDamage;
                    lifesistemslider.SetHealth(health);
                    armorsistemslider.SetArmor(armor);
                }

            }
            else
            {
                health -= damage;
                lifesistemslider.SetHealth(health);
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

                StartCoroutine(RespawnPlayer());
            }
        
        }

        public void GiveHealth(int amount, GameObject pickup)
        {
            if (health < maxHealth)
            {
                health += amount;
                lifesistemslider.SetHealth(health);
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
                armorsistemslider.SetArmor(armor);
                Destroy(pickup);
            }

            if(armor > maxArmor)
            {
                armor = maxArmor;
            }
        
        }

        private void ShowDamageFeedback()
        {
            StartCoroutine(ShowDamageEffect());
        }

        private IEnumerator ShowDamageEffect()
        {
            // Activate the red image
            playerHurtGameObject.SetActive(true);

            // Wait for 0.5 seconds
            yield return new WaitForSeconds(0.5f);

            // Deactivate the red image
            playerHurtGameObject.SetActive(false);
        }

        private void GameOver(string who)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            Debug.Log("GameOverEvent");
        
            CustomEvent GameOverEvent = new CustomEvent("GameOverEvent")
            {
                { "deathCount", pointSystem.deathCount },
                { "deathFall", pointSystem.deathFall },
                { "enemyType", who },
                { "levelIndex", currentSceneName }
            };

            // Record the event with AnalyticsService.Instance.CustomData
            AnalyticsService.Instance.RecordEvent(GameOverEvent);
            AnalyticsService.Instance.Flush();
        }

        private void LevelStart()
        {

            string currentSceneName = SceneManager.GetActiveScene().name;
            Debug.Log("nivel: " + currentSceneName);

            Debug.Log("LevelStart");
        
            CustomEvent LevelStartEvent = new CustomEvent("LevelStartEvent")
            {
                { "levelIndex", currentSceneName }
            };

            // Record the event with AnalyticsService.Instance.CustomData
            AnalyticsService.Instance.RecordEvent(LevelStartEvent);
            AnalyticsService.Instance.Flush();
        }

    }
}