using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentMovementController : MonoBehaviour
{
    [SerializeField]
    private CharacterData opponentData;

    private NavMeshAgent agent;

    private OpponentAnimationController animationController;

    private Transform finalPoint;

    public float OpponentVelocity { get { return agent.velocity.magnitude; } }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        finalPoint = GameObject.FindGameObjectWithTag("Finish Point").transform;
        agent?.SetDestination(finalPoint.position);
        agent.speed = 5f;
        // animationController.CurrentState = OpponentAnimationController.OpponentState.Walking;
        
    }
}
