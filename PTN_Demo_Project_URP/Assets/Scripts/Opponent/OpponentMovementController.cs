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

    private float timer = 1.5f, timeRemaining, randomSpeed;

    private bool isTimeDone;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        finalPoint = GameObject.FindGameObjectWithTag("Finish Line").transform;
        agent?.SetDestination(finalPoint.position);
        randomSpeed = Random.Range(2, 5);
        agent.speed = randomSpeed;
        timeRemaining = timer;
        // animationController.CurrentState = OpponentAnimationController.OpponentState.Walking;
    }

    private void Update()
    {
        CheckTimer();

        if (isTimeDone)
        {
            randomSpeed = Random.Range((float)2, (float)5);
            agent.speed = randomSpeed;
            isTimeDone = false;
        }
    }

    private void CheckTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0) return;

        timeRemaining = timer;
        isTimeDone = true;
    }
}
