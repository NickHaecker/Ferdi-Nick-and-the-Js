using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionGlue : MonoBehaviour { 

    public GameObject otherObject;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        otherObject.transform.position = transform.TransformPoint(
            pos);
    }
}
