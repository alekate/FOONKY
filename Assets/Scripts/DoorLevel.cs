using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevel : MonoBehaviour
{
    public string level;

    private void OnCollisionEnter(Collision other) 
    {
        SceneManager.LoadScene(level);    
    }
}