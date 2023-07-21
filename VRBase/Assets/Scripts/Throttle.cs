using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle : MonoBehaviour
{
    public GameObject handle;
    public float throttle;

    // Update is called once per frame
    void Update()
    {
        throttle = (handle.transform.localPosition.y -0.94501f) * (1f/(1.26501f- 0.94501f));
        throttle = Mathf.Clamp(throttle, 0, 1);
    }
}
