using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class NextLevelDoor : MonoBehaviour
{
    public GameObject endLevelUI;
    public GameObject gamePlayUI;
    public GameObject pauseMenuUI;
    public PlayerMoves PlayerMovementScript;
    public static bool GameIsPaused = false;
    private PointSystem pointSystem;
    private Timer timer;
    private PointRecorder pointRecorder;

    [SerializeField] private TextMeshProUGUI graffitiCountText;
    [SerializeField] private TextMeshProUGUI rifleKillsText;
    [SerializeField] private TextMeshProUGUI shotgunKillsText;
    [SerializeField] private TextMeshProUGUI pistolKillsText;
    [SerializeField] private TextMeshProUGUI countPointsText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI maxTimeLVL1Text;

    async void Start()
    {
        pointSystem = FindObjectOfType<PointSystem>();
        timer = FindObjectOfType<Timer>();
        pointRecorder = FindObjectOfType<PointRecorder>();

        // Initialize Unity services
        await UnityServices.InitializeAsync();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)) 
        {
            SceneManager.LoadScene("LEVEL2");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graffitiCountText.text = pointSystem.graffitiCount.ToString();
            rifleKillsText.text = pointSystem.rifleKill.ToString();
            shotgunKillsText.text = pointSystem.shotgunKill.ToString();
            pistolKillsText.text = pointSystem.pistolKill.ToString();
            countPointsText.text = pointSystem.countPoints.ToString();
            maxTimeLVL1Text.text = pointSystem.countPoints.ToString();

            // Update the timer text using the Timer components
            timerText.text = timer.timerText.text;


            // datos guardados
            PointRecorder.Instance.AddPoints(pointSystem.countPoints);
            PointRecorder.Instance.VerifyMaxTime(timer.ElapsedTime);

            maxTimeLVL1Text.text = FormatTime(pointRecorder.maxTimeLVL1);

            gamePlayUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            endLevelUI.SetActive(true);

            Time.timeScale = 0f; // This pauses the game
            GameIsPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerMovementScript.enabled = false;

            LevelEnd();
        }
    }
    
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LevelEnd()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        Debug.Log("LevelEndEvent");
        Debug.Log(currentSceneName);
        
        CustomEvent LevelEndEvent = new CustomEvent("LevelEndEvent")
        {
            { "levelGraffiti", pointSystem.graffitiCount },
            { "levelTime", timer.ElapsedTime }, // Use public property ElapsedTime
            { "levelIndex", currentSceneName }
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.RecordEvent(LevelEndEvent);
        AnalyticsService.Instance.Flush();
    }
}
