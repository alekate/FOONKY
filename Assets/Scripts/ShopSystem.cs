using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public GameObject rifle;
    public GameObject shotgun;
    public PP_PointRecorder PP_PointRecorder;

    void Start()
    {
        if (PP_PointRecorder.haveRifle)
        {
            Destroy(rifle);
        }

        if (PP_PointRecorder.haveShotgun)
        {
            Destroy(shotgun);
        }
    }

}
