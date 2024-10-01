using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    [SerializeField] bool canDealDamage;
    [SerializeField] bool hasDealDamage;

    [SerializeField] float damageRange;
    [SerializeField] int damagePoints;

    void Start()
    {
        canDealDamage = true;
        hasDealDamage = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage && !hasDealDamage)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, damageRange))
            {
                hasDealDamage = true;
                PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
                player.DamagePlayer(damagePoints, "D0g3");
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealDamage = false;
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * damageRange);   
    }
}
