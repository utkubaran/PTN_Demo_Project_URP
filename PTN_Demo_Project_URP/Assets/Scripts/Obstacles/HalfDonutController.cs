using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HalfDonutController : MonoBehaviour
{
    [SerializeField]
    private Transform movingStick;

    [SerializeField]
    private float movementDistance;

    private float timer, timeRemaining;

    private bool isTimeDone;

    private Vector3 restPosition;

    void Start()
    {
        timer = Random.Range(3f, 7f);
        timer = 1f;
        timeRemaining = timer;
        isTimeDone = false;
        restPosition = movingStick.position;
    }

    void Update()
    {
        CheckTimer();

        if (isTimeDone)
        {
            StartCoroutine(MoveStick());
            isTimeDone = false;
        }
    }

    private IEnumerator MoveStick()
    {
        float randomMovementDistance = Random.Range(movementDistance * 0.5f, movementDistance);
        movingStick.DOMove(movingStick.position + Vector3.left * randomMovementDistance, 0.3f);
        yield return new WaitForSeconds(0.5f);
        movingStick.DOMove(restPosition, 0.5f);
    }

    private void CheckTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0) return;

        timer = Random.Range(3f, 7f);
        timeRemaining = timer;
        isTimeDone = true;
    }
}
