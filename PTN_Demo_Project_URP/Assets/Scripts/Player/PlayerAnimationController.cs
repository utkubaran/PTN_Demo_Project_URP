using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public enum CharacterState { Idle, Walking }

    private CharacterState currentState = CharacterState.Idle;

    public CharacterState CurrentState { set { currentState = value; } }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentState = CharacterState.Idle;
    }

    void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        switch (currentState)
        {
            case CharacterState.Idle:
                animator?.SetBool("isWalking", false);
                break;
            case CharacterState.Walking:
                animator?.SetBool("isWalking", true);
                break;
            default:
                Debug.LogError("NO ANIMATION STATE!");
                break;
        }
    }
}
