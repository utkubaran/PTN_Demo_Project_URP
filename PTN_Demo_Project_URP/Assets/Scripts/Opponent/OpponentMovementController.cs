using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentMovementController : MonoBehaviour
{
    [SerializeField]
    private float xBorder;

    private NavMeshAgent agent;

    private OpponentAnimationController animationController;

    private Transform _transform, finalPoint;

    public float OpponentVelocity { get { return agent.velocity.magnitude; } }

    private float timer = 1.5f, timeRemaining, randomSpeed, horizontalPos;

    private bool isTimeDone, isPlaying;

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
        _transform = transform;
    }

    void Start()
    {
        finalPoint = GameObject.FindGameObjectWithTag("Finish Line").transform;
        agent?.SetDestination(finalPoint.position);
        randomSpeed = Random.Range((float)5, (float)7);
        agent.speed = randomSpeed;
        timeRemaining = timer;
        isPlaying = false;
    }

    private void Update()
    {
        if (!isPlaying)
        {
            agent.isStopped = true;
            return;
        }
        else
        {
            agent.isStopped = false;
        }

        CheckTimer();
        horizontalPos = Mathf.Clamp(_transform.position.x, -xBorder, xBorder);
        transform.position = new Vector3(horizontalPos, _transform.position.y, _transform.position.z);
    }

    private void CheckTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0) return;

        timeRemaining = timer;
        isTimeDone = true;
    }
    
    private void ChangeAgentSpeed()
    {
        if (isTimeDone)
        {
            randomSpeed = Random.Range((float)5, (float)7);
            agent.speed = randomSpeed;
            isTimeDone = false;
        }
    }
}
