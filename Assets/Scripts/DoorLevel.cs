using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* EasyTransition
{ }*/

public class DoorLevel : MonoBehaviour
{
    public string level;

    /*public Transform spawnPoint;
    private TransitionManager manager;
    public TransitionSettings transition;*/

    void Start()
    {
        //manager = TransitionManager.Instance();
    }

    private void OnCollisionEnter(Collision other)
    {
        NextLevel();

        /*manager.Transition(transition, 0f);
        StartCoroutine(NextLevel());*/
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(level);
    }
    /*private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }*/
}