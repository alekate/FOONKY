using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using AnalyticsEvent = Unity.Services.Analytics.Event;


public class NewBehaviourScript : MonoBehaviour
{
    private bool firstSession = true;

    async void Start()
    {
        if (firstSession)
        {
            await UnityServices.InitializeAsync();
            firstSession = false;
        }
    }

    public void ConsentGiven()
    {
        AnalyticsService.Instance.StartDataCollection();
    }

    public void LoadScene()
    {  
        var eventParams = new Dictionary<string, object>
        {
            {"userLevel", 2},
        };

        AnalyticsService.Instance.CustomData("LevelStartEvent", eventParams);
        AnalyticsService.Instance.Flush();
        
        
        SceneManager.LoadScene("Level1");
    }
}
