using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WheelManager : MonoBehaviour
{
    private List<BaseWheel> _wheelColliders;
    // Start is called before the first frame update
    void Start()
    {
        _wheelColliders = GetComponentsInChildren<BaseWheel>().ToList();
    }

    public void UpdateWheels(CarInputManager input, WheelData wheelData)
    {
        foreach (BaseWheel wheel in _wheelColliders)
        {
            wheel.UpdateWheels(input,wheelData);
        }
    }
}
