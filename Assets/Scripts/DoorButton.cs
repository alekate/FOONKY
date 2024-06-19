using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Animator anim;
    public bool keyNeed;
    public string key;
    public bool playerOn;
    public bool haveKey;

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
                anim.SetBool("open", true); 
            }
            else
            {
                if (haveKey)
                {
                    anim.SetBool("open", true);
                }
            } 
        }
    }
}
