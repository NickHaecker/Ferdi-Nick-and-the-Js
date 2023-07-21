using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class MovementStopper : MonoBehaviour

{
    public ActionBasedContinuousMoveProvider Component;
    public Transform playertransform;
    public TrackedPoseDriver posedriver;
    // Start is called before the first frame update
    void Start()
    {
        Component.enabled = false;
        posedriver.enabled = false;
        StartCoroutine(Restart());
        
    }

    // Update is called once per frame
    void Update()
    {
        //playertransform.position = new Vector3(-2.75f,0f,4.55000019f);
        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(8);
        Component.enabled = true;
    }
}
