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
        throttle = (handle.transform.localPosition.z -1.011f) * 2.5f;
        throttle = Mathf.Clamp(throttle, 0, 1);
    }
}
