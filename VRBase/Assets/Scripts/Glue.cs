using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    [SerializeField]
    private GameObject _otherObject; [SerializeField]
    private Vector3 _pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _otherObject.transform.position = transform.TransformPoint(
          transform.position);
    }
}
