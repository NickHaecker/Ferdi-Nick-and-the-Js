using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateEndHitbox : MonoBehaviour
{
    public TrainController traincontroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EndHitbox>(out EndHitbox eh))
        {
            traincontroller.ValidateEnd();
            Debug.Log("HitboxTriggered");
        }
    }
}
