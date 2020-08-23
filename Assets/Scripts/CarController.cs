using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WheelData
{
    public float motorToruqe;
    public float brakeTorque;
    public float steerAngle;
}
public class CarController : MonoBehaviour
{
    public CarInputManager input;
    public WheelManager wheelManager;

    public float motorTorque = 10000;
    public float brakeTorque = 10000;
    public float steerAngle = 35;

    private WheelData _wheelData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!input && !wheelManager)
            return;
        
        _wheelData.motorToruqe = motorTorque;
        _wheelData.brakeTorque = brakeTorque;
        _wheelData.steerAngle = steerAngle;
        wheelManager.UpdateWheels(input,_wheelData);
    }
}
