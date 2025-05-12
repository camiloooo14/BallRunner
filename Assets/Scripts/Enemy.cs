using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Diagnostics;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

   
    // Velocidades del enemigo
    public float normalSpeed = 19f;
    public float reducedSpeed = 15f;

    // Flag para rastrear si ya ha pasado Z = 530
    private bool hasPassedCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Establecer la velocidad inicial
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = normalSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el jugador existe
        if (player != null && navMeshAgent != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

        // Verificar si ha pasado la posición Z = 530
        if (!hasPassedCheckpoint && transform.position.z >= 530f)
        {
            // Reducir la velocidad
            navMeshAgent.speed = reducedSpeed;


            // Marcar que ya pasó el checkpoint para no repetir este código
            hasPassedCheckpoint = true;

           
        }
    }
}