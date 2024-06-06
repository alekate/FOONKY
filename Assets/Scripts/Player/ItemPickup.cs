using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;
    public string typeAmmo;
    public int amount;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isHealth)
            {
                other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
            }
            
            if(isArmor)
            {
                other.GetComponent<PlayerHealth>().GiveArmor(amount, this.gameObject);
            }
            
            if(isAmmo)
            {
                other.GetComponent<Backpack>().GiveAmmo(amount, typeAmmo, this.gameObject);
            }

            
        }    
    }
}
