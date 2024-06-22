using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    
    private float elapsedTime;

    public float ElapsedTime => elapsedTime; // Public property to access elapsedTime

    void Start()
    {
        elapsedTime = 0f;
        UnityServices.InitializeAsync();
        
        if(UnityServices.State == ServicesInitializationState.Initialized)
        {
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("AnalyticsCollection");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
