using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    // referencias
    private Transform playerTransform;
    private NavMesh navMesh;
    private MaquinaEstados maquinaEstados;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator enemyAnim;

    //Ataque
    public float attackCD = 3f;

    public float timePassed;
    //public float timeAtention;
    public float newDestinationCD = 0.5f;

    private void OnEnable() 
    {
        navMesh.ActualizarPuntoDestinoNavMeshAgent();
        enemyAnim.SetTrigger("persecusion");
        attackCD = 3f;
        newDestinationCD = 0.5f;
        timePassed = 0f;
    }

    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerMoves>().transform;
        maquinaEstados = GetComponent<MaquinaEstados>();
        navMesh = GetComponent<NavMesh>();
        enemyAnim = GetComponentInChildren<Animator>();
        
    }


    private void Update()
    {
        if(timePassed >= attackCD)
        {
            if (navMesh.EnRngo())
            {
                maquinaEstados.ActivarEstado(maquinaEstados.EstadoAtaque);
                timePassed = 0f;
                return;
            }
        }
        timePassed += Time.deltaTime;

        if (newDestinationCD <= 0 && navMesh.Detectado())
        {
            newDestinationCD = 0.5f;
            navMesh.ActualizarPuntoDestinoNavMeshAgent();
        }
        newDestinationCD -= Time.deltaTime; 
        //transform.LookAt(playerTransform);
    }

}
