using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutController : MonoBehaviour
{
    [SerializeField]
    private Transform movingStick;

    private float movementSpeed = 100f, timer, timeRemaining;

    private bool isTimeDone;

    private Vector3 restPosition;

    void Start()
    {
        timer = Random.Range(1f, 5f);
        timeRemaining = timer;
        isTimeDone = false;
        restPosition = movingStick.position;
    }

    void Update()
    {
        CheckTimer();

        if (isTimeDone)
        {
            MoveStick();
            isTimeDone = false;
        }
    }

    private void MoveStick()
    {
        Debug.Log("I worked!");
        // movingStick.position = Vector3.MoveTowards(movingStick.position, Vector3.left * 5f, movementSpeed * Time.deltaTime);
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
