using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using AnalyticsEvent = Unity.Services.Analytics.Event;


public class NewBehaviourScript : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public void ConsentGiven()
    {
        AnalyticsService.Instance.StartDataCollection();
    }

    public void LoadScene()
    {         
        SceneManager.LoadScene("Level1");
    }
}
