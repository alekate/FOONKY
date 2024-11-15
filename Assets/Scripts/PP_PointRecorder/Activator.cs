using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public PP_PointRecorder scriptToActive;

    // Start is called before the first frame update
    void Awake()
    {
        scriptToActive = GetComponent<PP_PointRecorder>();

    }

    void Update()
    {
        scriptToActive.enabled = true;
    }


}
