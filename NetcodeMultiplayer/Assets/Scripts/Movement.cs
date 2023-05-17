using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 6;
    [SerializeField]
    private float _turnSmoothTime = 0.1f;
    [SerializeField]
    private Transform _cam;
    [SerializeField]
    private Vector3 _moveDir;
    [SerializeField]
    private float _turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(gameObject.transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            _moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _characterController.Move(_moveDir.normalized * _speed * Time.fixedDeltaTime);
        }
    }
}
