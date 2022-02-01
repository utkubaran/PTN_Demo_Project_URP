using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControllerRB : MonoBehaviour
{
    private PlayerInputController playerInputController;
    
    private Rigidbody _rb;

    private void Awake()
    {
        playerInputController = this.GetComponent<PlayerInputController>();
        _rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        _rb.MovePosition(transform.position + playerInputController.MovementDirection * 1f * Time.deltaTime);
        // _rb.AddForce(playerInputController.MovementDirection.normalized * 2f, ForceMode.Impulse);
    }
}
