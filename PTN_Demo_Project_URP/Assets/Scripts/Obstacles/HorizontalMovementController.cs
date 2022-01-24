using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float xBorder;

    private Transform _transform;

    private Vector3 movementVector;

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x < xBorder)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        else if (transform.position.x > -xBorder)
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }


    }
}
