using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
      [SerializeField] Transform _camTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                this.transform.position = _camTransform.position;
        this.transform.rotation = _camTransform.rotation;
    }
}
