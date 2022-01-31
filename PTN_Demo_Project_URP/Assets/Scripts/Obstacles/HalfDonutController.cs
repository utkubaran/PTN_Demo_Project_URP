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

    private float movementSpeed = 100f, timer, timeRemaining;

    private bool isTimeDone;

    private Vector3 restPosition;

    void Start()
    {
        timer = Random.Range(1f, 5f);
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
        movingStick.DOMove(movingStick.position + Vector3.left * movementDistance, 0.2f);
        yield return new WaitForSeconds(0.5f);
        movingStick.DOMove(restPosition, 0.5f);
    }

    private void CheckTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0) return;

        timer = Random.Range(1f, 5f);
        timeRemaining = timer;
        isTimeDone = true;
    }
}
