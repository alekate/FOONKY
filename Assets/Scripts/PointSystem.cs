using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointSystem : MonoBehaviour
{
    public float countPoints;
    public int pistolKill;
    public int shotgunKill;
    public int rifleKill;
    public int totalKills;
    public int graffitiCount;
    public int deathCount;
    public int deathFall;



    public void CountPoints(int points, string gun)
    {
        switch (gun)
        {
            case "Pistol":
                countPoints += points;
                pistolKill++;
                totalKills++;
                break;

            case "Shotgun":
                countPoints += points;
                shotgunKill++;
                totalKills++;
                break;

            case "Rifle":
                countPoints += points;
                rifleKill++;
                totalKills++;
                
                break;

            case "Cartel":
                countPoints += points;
                graffitiCount++;

                Debug.Log("Cartel");

                break;

            default:
            break;
        }
    }


}