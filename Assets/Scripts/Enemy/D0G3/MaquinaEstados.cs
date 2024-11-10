using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstados : MonoBehaviour
{
    public MonoBehaviour EstadoNormal;
    public MonoBehaviour EstadoAtaque;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;

    private MonoBehaviour EstadoActual;

    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if (EstadoActual != null) EstadoActual.enabled = false;
        EstadoActual = nuevoEstado;
        EstadoActual.enabled = true;
    }
}
