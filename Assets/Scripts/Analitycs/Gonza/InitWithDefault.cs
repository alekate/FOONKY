using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EventManager;

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
        LevelStartEvent levelStart = new LevelStartEvent
        {
            level = 0,
        };

        AnalyticsService.Instance.RecordEvent(levelStart);
        AnalyticsService.Instance.Flush();
        SceneManager.LoadScene("Level0");
    }
}
