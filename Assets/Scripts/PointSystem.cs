using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public float countPoints;
    public int pistolKills;
    public int shotgunKills;
    public int rifleKills;
    public int CartelCount;

    public void CountPoints (int points, string gun)
    {
        switch (gun)
        {
            case "Pistol":
                countPoints += points;
                pistolKills ++;
            break;

            case "Shotgun":
                countPoints += points;
                shotgunKills ++;
            break;

            case "Rifle":
                countPoints += points;
                rifleKills ++;
            break;

            case "Cartel":
                countPoints += points;
                CartelCount ++;
            break;

            default:
            break;
        }
    }

}
