using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    public bool keyNeed;
    public string key;
    public bool playerOn;
    public bool haveKey;

    private void OnTriggerEnter(Collider other) 
    {
        playerOn = other.gameObject.CompareTag("Player");
        haveKey = other.GetComponent<Backpack>().KeyCheck(key);
    }

    private void Update() 
    {
        if (playerOn)
        {
            if (!keyNeed)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {    
                    door.SetActive(false);
                    this.GetComponent<Renderer>().material.color = Color.red;
                }   
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && haveKey)
                {
                    door.SetActive(false);
                    this.GetComponent<Renderer>().material.color = Color.red;
                }
            } 
        }
    }
}
