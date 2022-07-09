using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public float R { get; private set; }
    public float X { get; private set; }
    public float Y { get; private set; }
    public bool PushedStart { get; private set; }

    void Update()
    {
        R = 0f;
        Y = 0f;
        PushedStart = false;

        R = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        X = Input.GetAxis("Fire1") - Input.GetAxis("Fire2");
        PushedStart = Input.GetKeyDown(KeyCode.R);
    }
}
