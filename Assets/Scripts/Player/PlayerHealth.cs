using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthUI;
	[SerializeField] private TextMeshProUGUI armorUI;

    public int maxHealth;
    public int health;

    public int maxArmor;
    public int armor;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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

    public void DamagePlayer(int damage)
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
            Debug.Log("U Ded haha");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
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

}