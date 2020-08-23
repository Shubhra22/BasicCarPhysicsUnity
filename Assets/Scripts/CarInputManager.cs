using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CarInputManager : MonoBehaviour
{
    private PlayerInput _input;

    private float _throttle;
    private float _brake;
    private float _steer;

    public float Throttle => _throttle;

    public float Brake => _brake;

    public float Steer => _steer;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_input)
            return;

        HandleInput();
    }

    private void HandleInput()
    {
        _throttle = GetActionFloatValue("Throttle");
        _brake = GetActionFloatValue("Brake");
        _steer = GetActionFloatValue("Steer");
    }

    float GetActionFloatValue(string name)
    {
        float value = 0;
        InputAction inputAction = _input.actions.FindAction(name);
        if (inputAction != null)
        {
            value = inputAction.ReadValue<float>();
        }
        return value;

    }
}
