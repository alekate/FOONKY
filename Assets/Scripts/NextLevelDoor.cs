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

    [SerializeField] private TextMeshProUGUI graffitiCountText;
    [SerializeField] private TextMeshProUGUI rifleKillsText;
    [SerializeField] private TextMeshProUGUI shotgunKillsText;
    [SerializeField] private TextMeshProUGUI pistolKillsText;
    [SerializeField] private TextMeshProUGUI countPointsText;
    [SerializeField] private TextMeshProUGUI timerText;

    async void Start()
    {
        pointSystem = FindObjectOfType<PointSystem>();
        timer = FindObjectOfType<Timer>();

        // Initialize Unity services
        await UnityServices.InitializeAsync();
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

            // Update the timer text using the Timer component
            timerText.text = timer.timerText.text;

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

    private void LevelEnd()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        var eventParams = new Dictionary<string, object>
        {
            { "levelGraffiti", pointSystem.graffitiCount },
            { "levelTime", timer.ElapsedTime }, // Use public property ElapsedTime
            { "userLevel", currentSceneName }
        };

        // Record the event with AnalyticsService.Instance.CustomData
        AnalyticsService.Instance.CustomData("LevelEndEvent", eventParams);
        AnalyticsService.Instance.Flush();
    }
}
