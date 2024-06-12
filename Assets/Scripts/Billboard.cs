using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform player;

     void Start()
    {
        player = FindObjectOfType<PlayerMoves>().transform; 
    }

    void Update()
    {
        transform.LookAt(player.position);
    }
}
