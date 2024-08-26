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

        //UpdatePointText();
    }

    private void Update()
    {
        //UpdatePointText();
    }

    /*private void UpdatePointText()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "HIDEOUT")
        {
            pointText.text = absolutePoints.ToString();
        }
    }*/

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

    public void VerifyMaxTime(float levelTime)
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

    public void SetGraffittis(string level, int graffitisLvl, int graffitiMax)
    {
        switch (level)
        {
            case "LEVEL1":
                if (graffitisLvl > grafittisLVL1)
                {
                    grafittisLVL1 = graffitisLvl;
                }
                maxGrafLVL1 = graffitiMax;
            break;

            case "LEVEL2":
                if (graffitisLvl > grafittisLVL2)
                {
                    grafittisLVL2 = graffitisLvl;
                }
                maxGrafLVL2 = graffitiMax;
            break;

            case "LEVEL3":
                if (graffitisLvl > grafittisLVL3)
                {
                    grafittisLVL3 = graffitisLvl;
                }
                maxGrafLVL3 = graffitiMax;
            break;

            default:
            return;
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
}

