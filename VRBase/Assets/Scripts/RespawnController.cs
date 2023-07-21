using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
        }

        other.gameObject.transform.position= _spawn.transform.position;
    }
}
