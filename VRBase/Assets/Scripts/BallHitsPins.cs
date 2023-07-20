using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitsPins : MonoBehaviour
{
    private bool pinsHit = false;
    private Vector3 initialPosition;
    private Rigidbody ballRigidbody;

    private void Start()
    {
        initialPosition = transform.position;
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pin>() != null)
        {
            Debug.Log("getroffen");
            pinsHit = true;
        }
    }

    private void Update()
    {
        if (!pinsHit && transform.position.y < -1f)
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }
}
