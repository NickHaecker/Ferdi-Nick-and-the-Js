using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceHitBox : MonoBehaviour, Hitable
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private bool _canMove = false;

    private void OnEnable()
    {
        _canMove = true;
    }

    private void Update()
    {
        if(!_canMove)
        {
            return;
        }
        transform.Translate(-transform.forward * _speed * Time.deltaTime);
    }
    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            Remove();
        }
    }
}
