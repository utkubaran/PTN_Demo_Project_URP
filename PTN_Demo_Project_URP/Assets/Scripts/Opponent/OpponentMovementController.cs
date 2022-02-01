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

    private bool isTimeDone, isPlaying;
    public bool IsPlaying { set { isPlaying = value; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => isPlaying = false);
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelStart.AddListener( () => agent.isStopped = false );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnRaceFinish.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => isPlaying = false);
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelStart.RemoveListener( () => agent.isStopped = false );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
        EventManager.OnRaceFinish.RemoveListener( () => isPlaying = false );
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        finalPoint = GameObject.FindGameObjectWithTag("Finish Line").transform;
        agent?.SetDestination(finalPoint.position);
        randomSpeed = Random.Range((float)2, (float)5);
        agent.speed = randomSpeed;
        timeRemaining = timer;      
    }

    private void Update()
    {
        if (!isPlaying)
        {
            agent.isStopped = true;
            return;
        }

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
