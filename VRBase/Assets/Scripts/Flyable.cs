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
        _body.drag = _linearDrag;
        _body.angularDrag = _angularDrag;
    }

    public void Orbit()
    {
        _isInOrbit = true;

        ApplyRandomForce();
    }

    public void Ground()
    {
        _isInOrbit = false;
    }

    private void FixedUpdate()
    {
        if (!_isInOrbit)
        {
            return;
        }
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Vector3 gravityVector = transform.position.normalized * _gravity;
        _body.AddForce(gravityVector, ForceMode.Acceleration);
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
        ApplyRandomForce();
    }
}
