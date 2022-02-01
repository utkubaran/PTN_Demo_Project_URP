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

    private Rigidbody _rb;

    private void Awake()
    {
        _transform = transform;
        opponentMovementController = this.GetComponent<OpponentMovementController>();
        opponentAnimationController = this.GetComponent<OpponentAnimationController>();
        _rb = this.GetComponent<Rigidbody>();
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
            Debug.Log("worksssss!");
            this.transform.parent = other.transform;
        }
        else if (isStick)
        {
            _rb.AddForce(other.contacts[0].normal * 2f, ForceMode.Impulse);
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
