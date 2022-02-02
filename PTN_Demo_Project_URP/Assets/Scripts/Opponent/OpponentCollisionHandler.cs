using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float stickCollisionForce = 7.5f;

    [SerializeField][Range(0f, 2f)]
    private float respawnTimer;

    private OpponentMovementController opponentMovementController;

    private OpponentAnimationController opponentAnimationController;

    private NavMeshAgent agent;

    private Transform _transform, respawnPoint;

    private Rigidbody _rb;

    private void Awake()
    {
        _transform = transform;
        opponentMovementController = this.GetComponent<OpponentMovementController>();
        opponentAnimationController = this.GetComponent<OpponentAnimationController>();
        _rb = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn Point").transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        bool isObstacle = other.gameObject.GetComponent<Obstacle>();
        bool isRotatingPlatform = other.gameObject.GetComponent<RotatingPlatformController>();
        bool isStick = other.gameObject.GetComponent<Stick>();

        if (isObstacle)
        {
            StartCoroutine(Respawn());
        }
        else if (isRotatingPlatform)
        {
            this.transform.parent = other.transform;
        }
        else if (isStick)
        {
            _rb.AddForce(other.contacts[0].normal * stickCollisionForce, ForceMode.Impulse);
            StartCoroutine(Respawn());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        bool isRotatingPlatform = other.gameObject.GetComponent<RotatingPlatformController>();

        if (!isRotatingPlatform) return;

        this.transform.parent = null;
    }

    private IEnumerator Respawn()
    {
        agent.isStopped = true;
        // opponentMovementController.IsPlaying = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(respawnTimer);
        _transform.position = respawnPoint.position;
        GetComponent<Collider>().enabled = true;
        // opponentMovementController.IsPlaying = true;
        // agent.SetDestination(GameObject.FindGameObjectWithTag("Finish Line").transform.position);
        agent.isStopped = false;
    }
}
