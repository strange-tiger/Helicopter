using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotate : MonoBehaviour
{
    public float MaxPropellerSpeed = 10.0f;

    public GameObject Propeller;
    public GameObject TailPropeller;

    private HelicopterInput _input;
    public bool _isTurnOn = false;
    private bool _ableToFlight = false;

    void Awake()
    {
        _input = GetComponent<HelicopterInput>();
    }

    void Update()
    {
        if(_input.PushedStart)
        {
            _isTurnOn = !_isTurnOn;
        }

        if (_isTurnOn)
        {
            onTurnOn();
        }
        else
        {
            onTurnOff();
        }
    }

    private float _propellerSpeed = 0f;
    private void onTurnOn()
    {
        _propellerSpeed = Mathf.Lerp(_propellerSpeed, MaxPropellerSpeed, Time.deltaTime);
        rotatePropellers();

        if (MaxPropellerSpeed - _propellerSpeed > 0.5f)
        {
            return;
        }
        else
        {
            _ableToFlight = true;
        }
    }

    private void onTurnOff()
    {
        _propellerSpeed = Mathf.Lerp(_propellerSpeed, 0f, Time.deltaTime);
        rotatePropellers();
        _ableToFlight = false;
    }

    private void rotatePropellers()
    {
        Propeller.transform.Rotate(Vector3.up * _propellerSpeed, Space.Self);
        TailPropeller.transform.Rotate(Vector3.up * _propellerSpeed, Space.Self);
    }

    public bool getAbleToFlight()
    { 
        return _ableToFlight;
    }
}
