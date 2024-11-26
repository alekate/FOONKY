using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelRecord : MonoBehaviour
{
    public TextMeshPro timeText; 
    public TextMeshPro graffittiText; 
    public TextMeshPro enemiesText;
    public string level;
    public PP_PointRecorder PP_PointRecorder;


    void Update()
    {
        enemiesText.text = PP_PointRecorder.GetEnemies(level);
        
        float lvlTime = PP_PointRecorder.GetMaxTime(level);
        int minutes = Mathf.FloorToInt(lvlTime / 60);
        int seconds = Mathf.FloorToInt(lvlTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (lvlTime < 1) 
        {
            timeText.text = "No time";
        }

        graffittiText.text = PP_PointRecorder.GetGraffittis(level);

    }
}
