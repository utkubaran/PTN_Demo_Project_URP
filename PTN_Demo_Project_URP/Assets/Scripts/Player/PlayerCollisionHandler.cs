using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private float stickCollisionForce;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.isKinematic = false;
            _rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit!!!!!!");
        _rb.isKinematic = false;
        _rb.AddForce(other.contacts[0].normal.normalized * stickCollisionForce, ForceMode.Impulse);
    }
}
