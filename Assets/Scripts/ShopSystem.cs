using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public GameObject rifle;
    public GameObject shotgun;

    void Start()
    {
        if (PP_PointRecorder.Instance.haveRifle)
        {
            Destroy(rifle);
        }

        if (PP_PointRecorder.Instance.haveShotgun)
        {
            Destroy(shotgun);
        }
    }

}
