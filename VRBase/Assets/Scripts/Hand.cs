using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Action<Hitable> Hit;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Hitable>(out Hitable hitable))
        {
            Hit?.Invoke(hitable);
        }
    }
}
