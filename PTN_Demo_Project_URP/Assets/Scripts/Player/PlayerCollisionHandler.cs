using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float stickCollisionForce;

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
            _rb.AddForce(other.contacts[0].normal * 5f, ForceMode.Impulse);
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
        playerMovementController.IsPlaying = false;
        GetComponent<Collider>().enabled = false;
        playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Falling;
        yield return new WaitForSeconds(respawnTimer);
        playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Idle;
        GetComponent<Collider>().enabled = true;
        _transform.position = respawnPoint.position;
        playerMovementController.IsPlaying = true;
    }
}
