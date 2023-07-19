using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HitCallback();
public class BowlingBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _ballRigidbody;
    [SerializeField]
    private HitCallback _hitCallback;
    [SerializeField]
    private bool _hit = false;
    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (_hit)
        {
            return;
        }
        if (collision.gameObject.TryGetComponent<Pin>(out Pin pin))
        {
            StartCoroutine(PassCallback());
        }
    }

    IEnumerator PassCallback()
    {
        yield return new WaitForSeconds(5f);

        _hitCallback();
    }

    public void TakeMinigameController(TutorialController tutorialController)
    {
        _hitCallback = tutorialController.OnHitCallback;

        tutorialController.Reset += OnReset;
    }

    public void OnReset()
    {
        _ballRigidbody.velocity = Vector3.zero;
        _ballRigidbody.angularVelocity = Vector3.zero;

        //StopAllCoroutines();

        _hit = false;
    }
    public void OnReady()
    {

    }
}
