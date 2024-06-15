using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class PointSystem : MonoBehaviour
{
    public float countPoints;
    public int pistolKills;
    public int shotgunKills;
    public int rifleKills;
    public int graffitiCount;

    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public void CountPoints(int points, string gun)
    {
        switch (gun)
        {
            case "Pistol":
                countPoints += points;
                pistolKills++;
                break;

            case "Shotgun":
                countPoints += points;
                shotgunKills++;
                break;

            case "Rifle":
                countPoints += points;
                rifleKills++;
                
                break;

            case "Cartel":
                countPoints += points;
                graffitiCount++;

                Debug.Log("Cartel");

                CustomEvent LevelEndEvent = new CustomEvent("LevelEndEvent")
                {
                    { "levelGraffiti", graffitiCount }
                };
                AnalyticsService.Instance.RecordEvent(LevelEndEvent);
                AnalyticsService.Instance.Flush();

                break;

            default:
                break;
        }
    }
}