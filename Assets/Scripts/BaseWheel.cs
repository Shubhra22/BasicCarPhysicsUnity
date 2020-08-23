using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class BaseWheel : MonoBehaviour
{
    private WheelCollider _wheelCollider;
    public Transform wheelTransform;
    public bool isSteeringWheel;
    public bool isThrottleWheel;
    
    public float steerLerpSpeed;
    private float finalSteerAngle;
    // Start is called before the first frame update
    void Start()
    {
        _wheelCollider = GetComponent<WheelCollider>();
        
    }

    // Update is called once per frame
    public void UpdateWheels(CarInputManager inputManager, WheelData wheelData)
    {
        if(!_wheelCollider)
            return;
        HandleWheelTransform();
        HandleSteering(inputManager,wheelData);
        HandleMotorTorque(inputManager,wheelData);
        HandleBrakeTorque(inputManager,wheelData);

    }
    void HandleWheelTransform()
    {
        if (!wheelTransform) 
            return;
        
        Vector3 pos;
        Quaternion rot;
        _wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    void HandleSteering(CarInputManager inputManager, WheelData wheelData)
    {
        if(!isSteeringWheel)
            return;

        float curSteerAngle = inputManager.Steer * wheelData.steerAngle;
        _wheelCollider.steerAngle = Mathf.Lerp(_wheelCollider.steerAngle,curSteerAngle,Time.deltaTime * steerLerpSpeed);
    }

    void HandleMotorTorque(CarInputManager inputManager, WheelData wheelData)
    {
        if(!isThrottleWheel)
            return;
        _wheelCollider.motorTorque = inputManager.Throttle * wheelData.motorToruqe;
    }

    void HandleBrakeTorque(CarInputManager inputManager, WheelData wheelData)
    {
        _wheelCollider.brakeTorque = inputManager.Brake * wheelData.brakeTorque;
    }
}
