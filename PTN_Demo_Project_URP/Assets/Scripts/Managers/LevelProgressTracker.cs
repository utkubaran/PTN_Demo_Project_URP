using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    private Transform finishLine, playerPos;

    private float distanceToFinish, maxDistance;

    private bool isFinished;

    public float distanceCovered { get { return distanceToFinish / maxDistance; } }

    void Start()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish Line").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        isFinished = false;
        maxDistance = finishLine.position.z - playerPos.position.z;
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        distanceToFinish = finishLine.position.z - playerPos.position.z;

        if ((int)distanceToFinish <= 0 && !isFinished)
        {
            isFinished = true;
            distanceToFinish = 0;
            EventManager.OnRaceFinish?.Invoke();
        }
    }
}
