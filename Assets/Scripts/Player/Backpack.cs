using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public int currentShotgunAmmo = 5;
    public int maxShotgunAmmo = 20;
    public int currentPistolAmmo = 10;
    public int maxPistolAmmo = 30;
    public int currentRifleAmmo = 35;
    public int maxRifleAmmo = 100;
    public bool key1;
    public bool key2;

    public void GiveAmmo (int amount, string type, GameObject pickup)
    {
        switch (type)
        {
            case "Rifle": 
                if(currentRifleAmmo < maxRifleAmmo)
                {
                    currentRifleAmmo += amount;
                    Destroy(pickup);
                }

                if(currentRifleAmmo > maxRifleAmmo)
                {
                    currentRifleAmmo = maxRifleAmmo;
                }
            break;

            case "Pistol": 
                if(currentPistolAmmo < maxPistolAmmo)
                {
                    currentPistolAmmo += amount;
                    Destroy(pickup);
                }

                if(currentPistolAmmo > maxPistolAmmo)
                {
                    currentPistolAmmo = maxPistolAmmo;
                }
            break;

            case "Shotgun": 
                if(currentShotgunAmmo < maxShotgunAmmo)
                {
                    currentShotgunAmmo += amount;
                    Destroy(pickup);
                }

                if(currentShotgunAmmo > maxShotgunAmmo)
                {
                    currentShotgunAmmo = maxShotgunAmmo;
                }
            break;

            default: return;
        }
    }

    public void AmmoUsed (string type)
    {
        switch (type)
        {
            case "Rifle": 
                if (currentRifleAmmo > 0)
                {
                    currentRifleAmmo--;
                } 
            break;

            case "Pistol": 
                if (currentPistolAmmo > 0)
                {
                    currentPistolAmmo--;
                } 
            break;

            case "Shotgun": 
                if (currentShotgunAmmo > 0)
                {
                    currentShotgunAmmo--;
                } 
            break;

            default: return;
        }
    }
}
