using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Rigidbody))]
public class MoveProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject _hitParticles;
    [SerializeField]
    private float _shootForce;
    [SerializeField]
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = _rigidbody.transform.forward * _shootForce;    
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject hit = Instantiate(_hitParticles,transform.position,Quaternion.identity);
        hit.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        Destroy(gameObject);
    }
}
