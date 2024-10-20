using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{



    public void PlayGame()
    {
       
        StartCoroutine(Wait());
    }

    /*private void Start() 
    {
        PlayerPrefs.HasKey("HasDoneAnalytics", 0);
    }*/

   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f); //corutina adnashe
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
        SceneManager.LoadScene("Analytics");
        /*
        if (PlayerPrefs.HasKey("HasDoneAnalytics", 0) <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene("Analytics");
        }*/
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1;
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }

    public void Hideout()
    {
        SceneManager.LoadScene("HIDEOUT");
        Time.timeScale = 1;
    }

    public void Cinematic()
    {
        SceneManager.LoadScene("CINEMATIC");
        Time.timeScale = 1;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
