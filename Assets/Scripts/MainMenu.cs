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

   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f); //corutina adnashe
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
