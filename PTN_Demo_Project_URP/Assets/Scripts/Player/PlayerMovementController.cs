using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    CharacterData playerData;

    private PlayerInputController playerInputController;

    private PlayerAnimationController playerAnimationController;

    private float movementSpeed, rotationSpeed;

    private bool isPlaying;
    public bool IsPlaying { set { isPlaying = value; } }

    private Vector3 movementDirection;

    private Transform _transform;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnRaceFinish.AddListener( () => isPlaying = false );
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
        EventManager.OnRaceFinish.RemoveListener( () => isPlaying = false );
    }

    private void Awake()
    {
        playerInputController = GetComponent<PlayerInputController>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    void Start()
    {
        _transform = this.transform;
        movementSpeed = playerData.movementSpeed;
        rotationSpeed = playerData.rotationSpeed;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        if (playerAnimationController == null || playerInputController == null) return;

        movementDirection = playerInputController.MovementDirection;

        if (movementDirection.magnitude >= 0.1f && isPlaying)
        {
            // characterController.Move(movementDirection.normalized * Time.deltaTime * movementSpeed);
            transform.position += movementDirection.normalized * movementSpeed * Time.deltaTime;
            playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Walking;
        }
        else
        {
            playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Idle;
        }
    }

    private void RotatePlayer()
    {
        if ( movementDirection.magnitude == 0f || !isPlaying) return;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementDirection.normalized), rotationSpeed);
    }
}
