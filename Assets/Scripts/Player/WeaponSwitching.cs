
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0; //va activando y desactivando los index de las armas que son hijas empezando de arriba hacia abajo
    public GameObject weaponUI1;
    public GameObject weaponUI2;
    public GameObject weaponUI3; 
    public int previousSelectedWeapon;
    
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        //por defult el primer objeto que sea hijo siempre es 0

        previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0; 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && PointRecorder.Instance.haveShotgun) //se agrega la segunda condicon para ver si existe un segundo objeto q sea hijo 
        {
            selectedWeapon = 1;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && PointRecorder.Instance.haveRifle)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();            
        }

    }

    void SelectWeapon()
    {
        switch (selectedWeapon)
        {
            case 0:
                weaponUI1.SetActive(true); 
                weaponUI2.SetActive(false);
                weaponUI3.SetActive(false);
            break;

            case 1:
                if (PointRecorder.Instance.haveShotgun)
                {
                    weaponUI2.SetActive(true);
                    weaponUI1.SetActive(false);
                    weaponUI3.SetActive(false);
                }
                else
                {
                    previousSelectedWeapon++;
                    return;
                } 
            break;

            case 2:
                if (PointRecorder.Instance.haveRifle)
                {
                    weaponUI3.SetActive(true);
                    weaponUI1.SetActive(false);
                    weaponUI2.SetActive(false);
                }
                else
                {
                    previousSelectedWeapon = 0;
                    return;
                } 
            break;

            default:
                Debug.Log("error");
            break;
        }

        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {weapon.gameObject.SetActive(true);}
            else
            {weapon.gameObject.SetActive(false);}

            i++;
        }
    }
}
