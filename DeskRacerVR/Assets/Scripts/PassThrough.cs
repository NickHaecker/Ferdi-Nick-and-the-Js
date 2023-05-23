using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave.Native;

public class PassThrough : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Interop.WVR_ShowPassthroughUnderlay(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}