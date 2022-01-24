using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
