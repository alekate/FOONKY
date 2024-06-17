using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcensorScript : MonoBehaviour
{
    public Animator anim;
    public bool up = true;
    public bool down = false;
    public BoxCollider trigger;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("down", down);
        anim.SetBool("up", up);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
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

    public void ActiveCollider()
    {
        trigger.enabled = true;
    }

    public void DeactiveCollider()
    {
        trigger.enabled = false;
    }
}
