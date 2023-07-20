using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyable : MonoBehaviour
{
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _linearDrag = 0.1f;
    [SerializeField]
    private float _angularDrag = 0.1f;
    [SerializeField]
    private float _maxRandomForce = 10f;
    [SerializeField]
    public float _floatForce = 1f;
    [SerializeField]
    private Rigidbody _body;
    [SerializeField]
    private bool _isInOrbit = false;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    public void PrepareOrbit()
    {
        _body.useGravity = false;
        _body.angularVelocity = new Vector3(0.45f, 2, 1.1f);
    }

    public void Orbit()
    {
        _isInOrbit = true;
        ApplyGravity();
    }

    public void Ground()
    {
        _isInOrbit = false;
        _body.useGravity = true;
    }

    private void Update()
    {
        if (!_isInOrbit)
        {
            return;
        }
    }

    private void ApplyGravity()
    {
        _body.AddForce(new Vector3(1, 1, 1) * _floatForce, ForceMode.Force);
    }

    private void ApplyRandomForce()
    {
        Vector3 randomForce = new Vector3(Random.Range(-_maxRandomForce, _maxRandomForce), Random.Range(-_maxRandomForce, _maxRandomForce), Random.Range(-_maxRandomForce, _maxRandomForce));
        _body.AddForce(randomForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isInOrbit)
        {
            return;
        }

        Vector3 reflection = Vector3.Reflect(_body.velocity, collision.contacts[0].normal);
        _body.velocity = reflection;
    }
}
