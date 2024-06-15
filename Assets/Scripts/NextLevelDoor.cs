using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    void Start()
    {
        pointSystem = FindObjectOfType<PointSystem>();
        timer = FindObjectOfType<Timer>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            graffitiCountText.text = pointSystem.graffitiCount.ToString();
            rifleKillsText.text = pointSystem.rifleKills.ToString();
            shotgunKillsText.text = pointSystem.shotgunKills.ToString();
            pistolKillsText.text = pointSystem.pistolKills.ToString();
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
        }
    }
}
