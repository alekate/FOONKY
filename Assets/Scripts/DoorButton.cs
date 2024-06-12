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
    public Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

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
                    anim.SetBool("Active", true);
                }   
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && haveKey)
                {
                    anim.SetBool("Active", true);
                }
            } 
        }
    }
}
