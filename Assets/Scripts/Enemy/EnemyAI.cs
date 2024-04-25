using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playerTransform;
    private NavMeshAgent enemyNavMeshAgent;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Ataque
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float attackRange;
    public bool playerInAttackRange;

    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!enemyAwareness.isAggro == false && !playerInAttackRange) Patroling();
        if (enemyAwareness.isAggro == true && !playerInAttackRange) ChasePlayer();
        if (enemyAwareness.isAggro == true && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        enemyNavMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //llego al WalkPoint

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint() //busca un punto random
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    
    private void ChasePlayer()
    {
        if (enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            enemyNavMeshAgent.SetDestination(transform.position);
        }
    }

    private void AttackPlayer()
    {
        //para que el enemigo no se mueva
        enemyNavMeshAgent.SetDestination(transform.position);

        transform.LookAt(playerTransform);

        if(!alreadyAttacked)
        {


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;

    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
