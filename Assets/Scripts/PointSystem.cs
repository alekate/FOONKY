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
    public int enemyTotal;
    public int graffitiCount;
    public int graffitiTotal;
    public int deathCount;
    public int deathFall;


    private void Start() 
    {
        GameObject[] graffittis = GameObject.FindGameObjectsWithTag("Graffitti");

        foreach (GameObject graffitti in graffittis)
        {
           graffitiTotal++;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("TVFly");

        foreach (GameObject enemy in enemies)
        {
           enemyTotal++;
        }
    }

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

                break;

            default:
            break;
        }
    }


}