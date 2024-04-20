using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 15f;
    public float followingRadius = 30f;
    public bool isAggro;
    public Material aggroMaterial;
    public Material material;
    private Transform playerTransform;


    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);


        if (dist < awarenessRadius)
        {
            GetComponent<MeshRenderer>().material = aggroMaterial;
            isAggro = true;
            //Debug.Log("teveo lol");
        }

        if(dist > followingRadius)
        {
            GetComponent<MeshRenderer>().material = material;
            isAggro = false;
            //Debug.Log("NOteveo lol");
        }
    }

}
