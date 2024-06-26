using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointRecorder : MonoBehaviour
{
   public static PointRecorder Instance { get; private set;}

   [SerializeField] public float absolutePoints = 0;
   [SerializeField] public float maxTimeLVL1 = 0;
   [SerializeField] public float maxTimeLVL2 = 0;
   [SerializeField] public float maxTimeLVL3 = 0;
   [SerializeField] public bool haveRifle;
   [SerializeField] public bool haveShotgun;


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

   public void DecreasePoints(float levelPoints)
   {
        absolutePoints -= levelPoints;
   }

   public void BuyWeapon(string type)
   {
        switch (type)
        {
            case "Rifle":
                haveRifle = true;
            break;

            case "Shotgun":
                haveShotgun = true;
            break;

            default:
                Debug.Log("Weapon not found");
            break;
        }
   }

   public void ActiveShotgun()
   {
        haveShotgun = true;
   }

   public void VerifyMaxTime (float levelTime)
   {
      string currentSceneName = SceneManager.GetActiveScene().name;

      switch (currentSceneName)
      {
        case "LEVEL1":
            if (levelTime < maxTimeLVL1)
            {
                maxTimeLVL1 = levelTime;
            }
        break;

        case "LEVEL2":
            if (levelTime < maxTimeLVL2)
            {
                maxTimeLVL2 = levelTime;
            }
        break;

        case "LEVEL3":
            if (levelTime < maxTimeLVL3)
            {
                maxTimeLVL3 = levelTime;
            }
        break;

        default:
            Debug.Log("nivel no encontrado");
        break;
      }
   }

   public float GetMaxTime (string level)
   {
        switch (level)
        {
            case "LEVEL1":  
                return maxTimeLVL1;
            break;

            case "LEVEL2":  
                return maxTimeLVL2;
            break;

            case "LEVEL3":  
                return maxTimeLVL3;
            break;

            default:
                return 0;
            break;
        }
   }
}
