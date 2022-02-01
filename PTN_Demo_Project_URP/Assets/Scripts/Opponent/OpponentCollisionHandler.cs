using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollisionHandler : MonoBehaviour
{
[SerializeField][Range(0f, 2f)]
    private float respawnTimer;

    private OpponentMovementController opponentMovementController;

    private Transform _transform, respawnPoint;

    private Rigidbody _rb;

    private void Awake()
    {
        _transform = transform;
        opponentMovementController = GetComponent<OpponentMovementController>();
    }

    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn Point").transform;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.isKinematic = false;
            _rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit!!!!!!");
        bool isObstacle = other.gameObject.GetComponent<Obstacle>();
        
        if (!isObstacle) return;
        
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        opponentMovementController.IsPlaying = false;
        _rb.isKinematic = false;
        yield return new WaitForSeconds(respawnTimer);
        _rb.isKinematic = true;
        _transform.position = respawnPoint.position;
        opponentMovementController.IsPlaying = true;
    }
}
