using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelPainted : MonoBehaviour
{
    public int points;
    public bool playerOn;
    public bool painted;
    public Animator anim;
    public PointSystem pointSystem;
    

    private void Start() 
    {
        anim = GetComponent<Animator>();
        pointSystem = FindObjectOfType<PointSystem>();
        painted = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }

    private void Update() 
    {
        if (playerOn && !painted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {    
                anim.SetBool("Painted", true);
                pointSystem.CountPoints(points, "Cartel");
                painted = true; // Set the painted flag to true after counting points
            }   
        }
    }
}