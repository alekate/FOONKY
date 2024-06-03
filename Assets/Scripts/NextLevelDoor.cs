using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    public string nextLevel;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }    
    }
}
