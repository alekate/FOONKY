using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    // referencias
    private Transform playerTransform;
    private NavMeshAgent enemyNavMeshAgent;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator enemyAnim;

    //Patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Ataque
    public float attackRange = 1f;
    public float attackCD = 3f;
    public float aggroRange = 4f;
    float timePassed;
    float newDestinationCD = 0.5f;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMoves>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        GetComponentInChildren<Animation>();
    }

    private void Update()
    {
        if(timePassed >= attackCD)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) <= attackRange)
            {
                timePassed = 0f;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && Vector3.Distance(playerTransform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            enemyNavMeshAgent.SetDestination(playerTransform.position);
        }
        newDestinationCD -= Time.deltaTime;
        transform.LookAt(playerTransform);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

}
