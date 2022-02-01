using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator opponentAnimator;

    public enum OpponentState { Idle, Walking }

    private OpponentState currentState = OpponentState.Idle;
    public OpponentState CurrentState { set { currentState = value; } }

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => currentState = OpponentState.Idle );
        EventManager.OnLevelStart.AddListener( () => currentState = OpponentState.Walking );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => currentState = OpponentState.Idle );
        EventManager.OnLevelStart.RemoveListener( () => currentState = OpponentState.Walking );
    }

    void LateUpdate()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        switch (currentState)
        {
            case OpponentState.Idle:
                opponentAnimator?.SetBool("isWalking", false);
                break;
            case OpponentState.Walking:
                opponentAnimator?.SetBool("isWalking", true);
                break;
            default:
                Debug.LogError("NO ANIMATION STATE!");
                break;
        }
    }
}
