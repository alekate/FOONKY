using UnityEngine;

public class MoveCameraFollow : MonoBehaviour {

    public Transform player;

    void Update() {
        transform.position = player.transform.position;
    }
}
