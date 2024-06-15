using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelPainted : MonoBehaviour
{
    public int points;
    public bool playerOn;
    public Animator anim;
    public PointSystem pointSystem;
    

    private void Start() 
    {
        anim = GetComponent<Animator>();
        pointSystem = FindObjectOfType<PointSystem>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        playerOn = other.gameObject.CompareTag("Player");
    }

    private void Update() 
    {
        if (playerOn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {    
                anim.SetBool("Painted", true);
                pointSystem.CountPoints(points, "Cartel");
            }   
        }
    }
}
