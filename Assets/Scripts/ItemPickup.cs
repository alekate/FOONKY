using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public AudioSource pickUpSound;
    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;
    public string typeAmmo;
    public bool isKey;
    public int amount;

    void Start ()
    {
        pickUpSound = GetComponent<AudioSource>();
    }

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
                other.GetComponentInChildren<Gun>().BulletFind();
            }

            if(isKey)
            {
                other.GetComponent<Backpack>().GiveKey(typeAmmo, this.gameObject);
            }

            

        }    
    }

    private void OnDestroy() 
    {
        pickUpSound.Play();
    }
}
