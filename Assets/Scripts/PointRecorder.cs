using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointRecorder : MonoBehaviour
{
   public static PointRecorder Instance { get; private set;}

   [SerializeField] private float absolutePoints = 0;
   [SerializeField] private float maxTimeLVL1 = 0;
   [SerializeField] private float maxTimeLVL2 = 0;
   [SerializeField] private float maxTimeLVL3 = 0;

   private void Awake()
   {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);    
        }
   } 

   public void AddPoints(float levelPoints)
   {
        absolutePoints += levelPoints;
   }

   public void VerifyMaxTime (float levelTime)
   {
      string currentSceneName = SceneManager.GetActiveScene().name;

      switch (currentSceneName)
      {
        case "LEVEL1":
            if (levelTime > maxTimeLVL1)
            {
                maxTimeLVL1 = levelTime;
            }
        break;

        case "LEVEL2":
            if (levelTime > maxTimeLVL2)
            {
                maxTimeLVL2 = levelTime;
            }
        break;

        case "LEVEL3":
            if (levelTime > maxTimeLVL3)
            {
                maxTimeLVL3 = levelTime;
            }
        break;

        default:
            Debug.Log("nivel no encontrado");
        break;
      }
   }
}
