using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelRecord : MonoBehaviour
{
    public TextMeshPro timeText; 
    public TextMeshPro graffittiText; 
    public TextMeshPro enemiesText;
    public float lvlTime;

    public string level;
    public PP_PointRecorder PP_PointRecorder;

    void Update()
    {
        enemiesText.text = PP_PointRecorder.GetEnemies(level);
        graffittiText.text = PP_PointRecorder.GetGraffittis(level);
        lvlTime = PP_PointRecorder.GetMaxTime(level);

        if (lvlTime < 1)
        {
            timeText.text = "No time";
        }
        else
        {
            int minutes = Mathf.FloorToInt(lvlTime / 60);
            int seconds = Mathf.FloorToInt(lvlTime % 60);
            timeText.text = $"{minutes:00}:{seconds:00}";
        }

        Debug.Log($"Level: {level}");
        Debug.Log($"Enemies Text: {PP_PointRecorder.GetEnemies(level)}");
        Debug.Log($"Time Text: {PP_PointRecorder.GetMaxTime(level)}");
        Debug.Log($"Graffittis Text: {PP_PointRecorder.GetGraffittis(level)}");
    }



}

