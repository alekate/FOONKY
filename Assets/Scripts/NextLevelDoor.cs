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
    private PP_PointRecorder pointRecorder;
    string currentSceneName;

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
        currentSceneName = SceneManager.GetActiveScene().name;
        await UnityServices.InitializeAsync();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graffitiCountText.text = pointSystem.graffitiCount.ToString() + " / " + pointSystem.graffitiTotal.ToString();
            rifleKillsText.text = pointSystem.rifleKill.ToString();
            shotgunKillsText.text = pointSystem.shotgunKill.ToString();
            pistolKillsText.text = pointSystem.pistolKill.ToString();
            countPointsText.text = pointSystem.countPoints.ToString();
            maxTimeLVL1Text.text = pointSystem.countPoints.ToString();

            // Actualiza el texto del timer usando los datos de tiempo guardados
            timerText.text = timer.timerText.text; // Esto actualizará el texto de tiempo en la UI de fin de nivel

            // Datos guardados
            PP_PointRecorder.Instance.AddPoints(pointSystem.countPoints);
            PP_PointRecorder.Instance.SetLevelStats(currentSceneName, pointSystem.graffitiCount, pointSystem.graffitiTotal, timer.ElapsedTime, pointSystem.totalKills, pointSystem.enemyTotal);
            float maxTime = PP_PointRecorder.Instance.maxTimeLVL1;
            maxTimeLVL1Text.text = FormatTime(maxTime);

            gamePlayUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            endLevelUI.SetActive(true);

            Time.timeScale = 0f; // Esto pausa el juego
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
        Debug.Log("LevelEndEvent");
        Debug.Log(currentSceneName);
        
        CustomEvent LevelEndEvent = new CustomEvent("LevelEndEvent")
        {
            { "levelGraffiti", pointSystem.graffitiCount },
            { "levelTime", timer.ElapsedTime },
            { "levelIndex", currentSceneName }
        };

        AnalyticsService.Instance.RecordEvent(LevelEndEvent);
        AnalyticsService.Instance.Flush();
    }
}
