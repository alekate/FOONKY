using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TextMeshPro descriptionText;
    private bool playerOn;

    [Header("caracteristcas")]
    public string tag;
    public string description;
    public float cost;

    private void Start()
    {
        tag = gameObject.tag;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerOn && PointRecorder.Instance.absolutePoints >= cost) 
        {
            PointRecorder.Instance.DecreasePoints(cost);
            PointRecorder.Instance.BuyWeapon(tag);
            Debug.Log("comprado");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            descriptionText.text = description;
            playerOn = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            descriptionText.text = "...";
            playerOn = false;   
        }
    }
}
