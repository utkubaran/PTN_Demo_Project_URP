using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    CharacterData playerData;

    [SerializeField]
    private float xBorder;

    private PlayerInputController playerInputController;

    private PlayerAnimationController playerAnimationController;

    private float movementSpeed, swerveSpeed, rotationSpeed, horizontalPos, verticalPos;

    private bool isPlaying;
    public bool IsPlaying { set { isPlaying = value; } }

    private Vector3 movementDirection;

    private Transform _transform;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelStart.AddListener( () => playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Walking );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnRaceFinish.AddListener( () => isPlaying = false );
    }
    
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelStart.RemoveListener( () => playerAnimationController.CurrentState = PlayerAnimationController.CharacterState.Walking );
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
        swerveSpeed = playerData.swerveSpeed;
        rotationSpeed = playerData.rotationSpeed;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (playerAnimationController == null || playerInputController == null || !isPlaying) return;

        movementDirection = playerInputController.MovementDirection;

        if (movementDirection.magnitude >= 0.1f)
        {
            horizontalPos = Mathf.Clamp(movementDirection.normalized.x * swerveSpeed * Time.deltaTime + _transform.position.x, -xBorder, xBorder);
        }

        verticalPos = movementSpeed * Time.deltaTime + _transform.position.z;
        Vector3 movementVector = new Vector3(horizontalPos, 0f, verticalPos);
        _transform.position = movementVector;
        
    }

    private void RotatePlayer()
    {
        if ( movementDirection.magnitude == 0f || !isPlaying) return;

        _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(movementDirection.normalized), rotationSpeed);
    }
}
