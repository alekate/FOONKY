using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [HideInInspector]
    public Transform perseguirObjetivo;
    private NavMeshAgent navMeshAgent;

    public float aggroRange = 4f;
    public float attackRange = 1f;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        perseguirObjetivo = FindObjectOfType<PlayerMoves>().transform;
    }

    public void ActualizarPuntoDestinoNMA(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNMA(perseguirObjetivo.position);
    }

    public void DetenerNMA()
    {
        navMeshAgent.isStopped = true;
    }

    public bool HemosLlegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

    public bool Detectado()
    {
        return Vector3.Distance(perseguirObjetivo.position, transform.position) <= aggroRange;
    }

    public bool EnRngo()
    {
        return Vector3.Distance(perseguirObjetivo.position, transform.position) <= attackRange;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
