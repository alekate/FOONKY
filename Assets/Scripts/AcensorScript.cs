using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcensorScript : MonoBehaviour
{
    public Animator anim;
    public bool up = true;
    public bool down = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("down", down);
        anim.SetBool("up", up);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {    
            anim.SetTrigger("active");
        }    
    }

    public void SetUp()
    {
        down = false;
        up = true;
        anim.SetBool("down", down);
        anim.SetBool("up", up);
    }

    public void SetDown()
    {
        up = false;
        down = true;
        anim.SetBool("down", down);
        anim.SetBool("up", up);
    }
}
