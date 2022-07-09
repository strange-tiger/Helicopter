using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float YSpeed = 12f;
    public float XSpeed = 0.12f;
    public float RotateSpeed = 1.2f;

    private HelicopterInput _input;
    private PropellerRotate _engine;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _input = GetComponent<HelicopterInput>();
        _engine = GetComponent<PropellerRotate>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!_engine.getAbleToFlight())
        {
            _rigidbody.useGravity = true;
            return;
        }

        _rigidbody.useGravity = false;
        if (_input.Y == 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            _rigidbody.AddForce(0f, _input.Y * YSpeed, 0f);
            // transform.Translate(Vector3.up * _input.Y * YSpeed, Space.Self);
        }

        if (_input.X == 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            transform.Translate(Vector3.forward * _input.X * XSpeed, Space.Self);
        }

        transform.Rotate(0f, _input.R * RotateSpeed, 0f);
    }
}
