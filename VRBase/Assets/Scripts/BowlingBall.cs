using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        XRGrabInteractable xRGrabInteractable = gameObject.GetComponent<XRGrabInteractable>();
        xRGrabInteractable.selectEntered.AddListener(OnSelectEntered);

    }
    private void OnSelectEntered(SelectEnterEventArgs arg0)
    {
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Bowling/ThrowTheBall");
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
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
            _hitCallback();
        }
        /* if ( collision.gameObject.name == "Plane")
        {
            
        } */
    }

    //IEnumerator PassCallback()
    //{
    //    yield return new WaitForSeconds(5f);

    //    _hitCallback();
    //}

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
