using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollisionHandler : MonoBehaviour
{
    [SerializeField][Range(0f, 2f)]
    private float respawnTimer;

    private OpponentMovementController opponentMovementController;

    private OpponentAnimationController opponentAnimationController;

    private Transform _transform, respawnPoint;

    private void Awake()
    {
        _transform = transform;
        opponentMovementController = GetComponent<OpponentMovementController>();
        opponentAnimationController = GetComponent<OpponentAnimationController>();
    }

    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn Point").transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        bool isObstacle = other.gameObject.GetComponent<Obstacle>();
        
        if (!isObstacle) return;
        
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        opponentMovementController.IsPlaying = false;
        GetComponent<Collider>().enabled = false;
        opponentAnimationController.CurrentState = OpponentAnimationController.OpponentState.Falling;
        yield return new WaitForSeconds(respawnTimer);
        opponentAnimationController.CurrentState = OpponentAnimationController.OpponentState.Idle;
        _transform.position = respawnPoint.position;
        GetComponent<Collider>().enabled = true;
        opponentMovementController.IsPlaying = true;
    }
}
