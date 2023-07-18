using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGage : MonoBehaviour
{
    private const float MaxNeedleAngle = 180;
    private const float MinNeedleAngle = 0;

    public Furnance furnance;

    private Transform needleTransform;

    private float fuelMax;
    private float fuel;

    // Start is called before the first frame update
    private void Awake()
    {
        needleTransform = this.transform;

        fuel = 0f;
        fuelMax = 50f;
    }

    // Update is called once per frame
    private void Update()
    {
        fuel = furnance.CoalLeft;
        if (fuel > fuelMax) fuel = fuelMax;

        needleTransform.eulerAngles = new Vector3(0, GetFuelRotation(), 0);
    }

    private float GetFuelRotation()
    {
        float totalAngleSize = MinNeedleAngle - MaxNeedleAngle;
        float fuelNormalized = fuel / fuelMax;

        return MinNeedleAngle - fuelNormalized * totalAngleSize;
    }
}
