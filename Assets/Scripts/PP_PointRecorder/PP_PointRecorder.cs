using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PP_PointRecorder : MonoBehaviour
{
    public static PP_PointRecorder Instance { get; private set; }

    [SerializeField] public float absolutePoints = 0;


    [SerializeField] public int enemyCount1 = 0;
    [SerializeField] public int totalEnemies1 = 0;
    [SerializeField] public float maxTimeLVL1 = 0;
    [SerializeField] public int grafittisLVL1 = 0;
    [SerializeField] public int maxGrafLVL1 = 0;

    [SerializeField] public float maxTimeLVL2 = 0;
    [SerializeField] public int grafittisLVL2 = 0;
    [SerializeField] public int maxGrafLVL2 = 0;
    [SerializeField] public int enemyCount2 = 0;
    [SerializeField] public int totalEnemies2 = 0;

    [SerializeField] public float maxTimeLVL3 = 0;
    [SerializeField] public int grafittisLVL3 = 0;
    [SerializeField] public int maxGrafLVL3 = 0;
    [SerializeField] public int enemyCount3 = 0;
    [SerializeField] public int totalEnemies3 = 0;

    [SerializeField] public bool haveRifle;
    [SerializeField] public bool haveShotgun;

    public TextMeshProUGUI pointText;

    private void Awake()
    {
        GameObject puntos = GameObject.Find("Points");
        pointText = puntos.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Instance = this;
        absolutePoints = PlayerPrefs.GetFloat("AbsolutePoints");
        UpdatePointText();

        if(PlayerPrefs.HasKey("Rifle"))
        {
          haveRifle = true;  
        }

        if(PlayerPrefs.HasKey("Shotgun"))
        {
          haveShotgun = true;  
        }

        if (PlayerPrefs.HasKey("LVL1Complete"))
        {
            grafittisLVL1 = PlayerPrefs.GetInt("grafittisLVL1");
            maxTimeLVL1 = PlayerPrefs.GetFloat("maxTimeLVL1");
            enemyCount1 = PlayerPrefs.GetInt("enemyCount1");
            totalEnemies1 = PlayerPrefs.GetInt("totalEnemies1");
            maxGrafLVL1 = PlayerPrefs.GetInt("maxGrafLVL1");
        }

        if (PlayerPrefs.HasKey("LVL2Complete"))
        {
            grafittisLVL2 = PlayerPrefs.GetInt("grafittisLVL2");
            maxTimeLVL2 = PlayerPrefs.GetFloat("maxTimeLVL2");
            enemyCount2 = PlayerPrefs.GetInt("enemyCount2");
            totalEnemies2 = PlayerPrefs.GetInt("totalEnemies2");
            maxGrafLVL2 = PlayerPrefs.GetInt("maxGrafLVL2");
        }

        if (PlayerPrefs.HasKey("LVL3Complete"))
        {
            grafittisLVL3 = PlayerPrefs.GetInt("grafittisLVL3");
            maxTimeLVL3 = PlayerPrefs.GetFloat("maxTimeLVL3");
            enemyCount3 = PlayerPrefs.GetInt("enemyCount3");
            totalEnemies2 = PlayerPrefs.GetInt("totalEnemies2");
            maxGrafLVL2 = PlayerPrefs.GetInt("maxGrafLVL2");
        }


    }


    public void AddPoints(float levelPoints)
    {
        absolutePoints += levelPoints;
        PlayerPrefs.SetFloat("AbsolutePoints", absolutePoints);
        UpdatePointText();
    }

    public void DecreasePoints(float levelPoints)
    {
        absolutePoints -= levelPoints;
        PlayerPrefs.SetFloat("AbsolutePoints", absolutePoints);
        UpdatePointText();
    }

    public void BuyWeapon(string type)
    {
        switch (type)
        {
            case "Rifle":
                haveRifle = true;
                PlayerPrefs.SetString("Rifle", "yes");
                break;

            case "Shotgun":
                haveShotgun = true;
                PlayerPrefs.SetString("Shotgun", "yes");
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
                
                PlayerPrefs.SetString("LVL1Complete", "yes");

                if (graffitisLvl > grafittisLVL1)
                {
                    grafittisLVL1 = graffitisLvl;
                    PlayerPrefs.SetInt("grafittisLVL1", grafittisLVL1);
                }
                maxGrafLVL1 = graffitiMax;
                PlayerPrefs.SetInt("maxGrafLVL1", maxGrafLVL1);

                if (levelTime < maxTimeLVL1)
                {
                    maxTimeLVL1 = levelTime;
                    PlayerPrefs.SetFloat("maxTimeLVL1", maxTimeLVL1);
                }

                if (enemyKilled > enemyCount1)
                {
                    enemyCount1 = enemyKilled;
                    PlayerPrefs.SetInt("enemyCount1", enemyCount1);
                }
                totalEnemies1 = totalEnemies;
                PlayerPrefs.SetInt("totalEnemies1", totalEnemies1);   
            break;

            case "LEVEL2":

                PlayerPrefs.SetString("LVL2Complete", "yes");

                if (graffitisLvl > grafittisLVL2)
                {
                    grafittisLVL2 = graffitisLvl;
                    PlayerPrefs.SetInt("grafittisLVL2", grafittisLVL2);
                }
                maxGrafLVL2 = graffitiMax;
                PlayerPrefs.SetInt("maxGrafLVL2", maxGrafLVL2);

                if (levelTime < maxTimeLVL2)
                {
                    maxTimeLVL2 = levelTime;
                    PlayerPrefs.SetFloat("maxTimeLVL2", maxTimeLVL2);
                }

                if (enemyKilled > enemyCount2)
                {
                    enemyCount2 = enemyKilled;
                    PlayerPrefs.SetInt("enemyCount2", enemyCount2);
                }
                totalEnemies2 = totalEnemies;
                PlayerPrefs.SetInt("totalEnemies2", totalEnemies2);   
            break;

            case "LEVEL3":

                PlayerPrefs.SetString("LVL3Complete", "yes");

                if (graffitisLvl > grafittisLVL3)
                {
                    grafittisLVL3 = graffitisLvl;
                    PlayerPrefs.SetInt("grafittisLVL3", grafittisLVL3);
                }
                maxGrafLVL3 = graffitiMax;
                PlayerPrefs.SetInt("maxGrafLVL3", maxGrafLVL3);

                if (levelTime < maxTimeLVL3)
                {
                    maxTimeLVL3 = levelTime;
                    PlayerPrefs.SetFloat("maxTimeLVL3", maxTimeLVL3);
                }

                if (enemyKilled > enemyCount3)
                {
                    enemyCount3 = enemyKilled;
                    PlayerPrefs.SetInt("enemyCount3", enemyCount3);
                }
                totalEnemies3 = totalEnemies;
                PlayerPrefs.SetInt("totalEnemies3", totalEnemies3);   
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

    public void UpdatePointText()
    {
        pointText.text = absolutePoints.ToString();
    }

}

