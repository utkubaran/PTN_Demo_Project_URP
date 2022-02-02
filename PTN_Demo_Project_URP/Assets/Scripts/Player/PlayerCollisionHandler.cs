using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float stickCollisionForce = 7.5f;

    [SerializeField][Range(0f, 2f)]
    private float respawnTimer;

    private PlayerMovementController playerMovementController;

    private PlayerAnimationController playerAnimationController;

    private Transform _transform, respawnPoint;

    private Rigidbody _rb;

    private void Awake()
    {
        _transform = transform;
        playerMovementController = GetComponent<PlayerMovementController>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn Point").transform;
        _rb = GetComponent<Rigidbody>();
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
            _transform.parent = other.transform;
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

        _transform.rotation = Quaternion.Euler(Vector3.zero);
        this.transform.parent = null;
    }

    private IEnumerator Respawn()
    {
        playerMovementController.IsPlaying = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(respawnTimer);
        GetComponent<Collider>().enabled = true;
        _transform.position = respawnPoint.position;
        playerMovementController.IsPlaying = true;
    }
}
