using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPoints : MonoBehaviour
{
    private TextMeshProUGUI score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = ("Points: " + PointRecorder.Instance.absolutePoints.ToString());
    }


}
