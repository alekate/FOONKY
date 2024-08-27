using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;

public class PointRecorder : MonoBehaviour
{
    public static PointRecorder Instance { get; private set; }

    [SerializeField] public float absolutePoints = 0;
    [SerializeField] public float maxTimeLVL1 = 0;
    [SerializeField] public int grafittisLVL1 = 0;
    [SerializeField] public int maxGrafLVL1 = 0;
    [SerializeField] public float maxTimeLVL2 = 0;
    [SerializeField] public int grafittisLVL2 = 0;
    [SerializeField] public int maxGrafLVL2 = 0;
    [SerializeField] public float maxTimeLVL3 = 0;
    [SerializeField] public int grafittisLVL3 = 0;
    [SerializeField] public int maxGrafLVL3 = 0;
    [SerializeField] public int enemyCount1 = 0;
    [SerializeField] public int totalEnemies1 = 0;
    [SerializeField] public int enemyCount2 = 0;
    [SerializeField] public int totalEnemies2 = 0;
    [SerializeField] public int enemyCount3 = 0;
    [SerializeField] public int totalEnemies3 = 0;
    [SerializeField] public bool haveRifle;
    [SerializeField] public bool haveShotgun;

   // public TextMeshProUGUI pointText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void AddPoints(float levelPoints)
    {
        absolutePoints += levelPoints;
        //UpdatePointText();
    }

    public void DecreasePoints(float levelPoints)
    {
        absolutePoints -= levelPoints;
        //UpdatePointText();
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

    public void SetLevelStats(string level, int graffitisLvl, int graffitiMax, float levelTime, int enemyKilled, int totalEnemies)
    {
        switch (level)
        {
            case "LEVEL1":
                if (graffitisLvl > grafittisLVL1)
                {
                    grafittisLVL1 = graffitisLvl;
                }
                maxGrafLVL1 = graffitiMax;

                if (levelTime < maxTimeLVL1)
                {
                    maxTimeLVL1 = levelTime;
                }

                if (enemyKilled > enemyCount1)
                {
                    enemyCount1 = enemyKilled;
                }
                totalEnemies1 = totalEnemies;
            break;

            case "LEVEL2":
                if (graffitisLvl > grafittisLVL2)
                {
                    grafittisLVL2 = graffitisLvl;
                }
                maxGrafLVL2 = graffitiMax;

                if (levelTime < maxTimeLVL2)
                {
                    maxTimeLVL2 = levelTime;
                }

                if (enemyKilled > enemyCount2)
                {
                    enemyCount2 = enemyKilled;
                }
                totalEnemies2 = totalEnemies;
            break;

            case "LEVEL3":
                if (graffitisLvl > grafittisLVL3)
                {
                    grafittisLVL3 = graffitisLvl;
                }
                maxGrafLVL3 = graffitiMax;

                if (levelTime < maxTimeLVL3)
                {
                    maxTimeLVL3 = levelTime;
                }

                if (enemyKilled > enemyCount3)
                {
                    enemyCount3 = enemyKilled;
                }
                totalEnemies3 = totalEnemies;
            break;

            default:
            return;
        }
    }

    public float GetMaxTime(string level)
    {
        switch (level)
        {
            case "LEVEL1":
                return maxTimeLVL1;

            case "LEVEL2":
                return maxTimeLVL2;

            case "LEVEL3":
                return maxTimeLVL3;

            default:
                return 0;
        }
    }

    public string GetGraffittis(string level)
    {
        string graffitText = "";

        switch (level)
        {
            case "LEVEL1":
                return graffitText = grafittisLVL1.ToString() + "/" + maxGrafLVL1.ToString();

            case "LEVEL2":
                return graffitText = grafittisLVL2.ToString() + "/" + maxGrafLVL2.ToString();

            case "LEVEL3":
                return graffitText = grafittisLVL3.ToString() + "/" + maxGrafLVL3.ToString();

            default:
                return "Not Found";
        }
    }

    public string GetEnemies(string level)
    {
        string enemiesText = "";

        switch (level)
        {
            case "LEVEL1": 
                return enemiesText = enemyCount1.ToString() + "/" + totalEnemies1.ToString();

            case "LEVEL2":
                return enemiesText = enemyCount2.ToString() + "/" + totalEnemies2.ToString();

            case "LEVEL3":
                return enemiesText = enemyCount3.ToString() + "/" + totalEnemies3.ToString();

            default:
                return "Not Found";
        }
    }

}

