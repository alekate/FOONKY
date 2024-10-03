using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePatrulla : MonoBehaviour
{
    public Transform[] WayPoints;
    private NavMesh navMesh;
    private MaquinaEstados maquinaEstados;
    public Animator enemyAnim;
    private int siguienteWayPoint;
    
    void Awake()
    {
        navMesh = GetComponent<NavMesh>();
        maquinaEstados = GetComponent<MaquinaEstados>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(navMesh.Detectado())
        {
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoPersecucion);
            return;
        }

        if (navMesh.HemosLlegado())
        {
            siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            ActualizarWayPointDestino();
        }
    }

    void OnEnable()
    {
        ActualizarWayPointDestino();
        enemyAnim.SetTrigger("patrulla");
    }

    void ActualizarWayPointDestino()
    {
        navMesh.ActualizarPuntoDestinoNMA(WayPoints[siguienteWayPoint].position);
    }

}
