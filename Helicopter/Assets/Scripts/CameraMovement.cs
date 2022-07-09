using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;

    private Vector3 _distance;
    void Start()
    {
        _distance = Target.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = Target.position - _distance;
    }
}
