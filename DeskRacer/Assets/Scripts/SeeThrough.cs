using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave.Native;

public class SeeThrough : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Interop.WVR_ShowPassthroughOverlay(true); //Show Passthrough Overlay
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
