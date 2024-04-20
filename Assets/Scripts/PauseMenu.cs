using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 
    public GameObject gamePlayUI; 
    public PlayerMovement PlayerMovementScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gamePlayUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //1 es el tiempo normal
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        PlayerMovementScript.enabled = true;


    }

    void Pause()
    {
        gamePlayUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //podes poner mas para asi dar un efecto de slowmo
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        PlayerMovementScript.enabled = false;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MENU");
    }


}
