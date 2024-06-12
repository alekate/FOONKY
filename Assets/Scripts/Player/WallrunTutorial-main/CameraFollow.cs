using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform cameraPosition;

    private void Update() 
    {
        transform.position = cameraPosition.position;    
    }
}

