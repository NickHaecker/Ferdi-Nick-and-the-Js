using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialController : MiniGameController
{
    public Action Reset;

    [SerializeField]
    private BowlingBall _bowlingBall;
    [SerializeField]
    private bool _isHolding = false;
    [SerializeField]
    private bool _finished = false;


    protected override void OnStart()
    {
        _bowlingBall.TakeMinigameController(this);
        XRGrabInteractable xRGrabInteractable = _bowlingBall.gameObject.GetComponent<XRGrabInteractable>();

        xRGrabInteractable.interactionManager = Player.Instance.GetInteractionManager();

        xRGrabInteractable.selectExited.AddListener(OnSelectExited);
        xRGrabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs arg0)
    {
        _isHolding = true;
    }

    protected override void OnSceneCloser()
    {
        //base.OnSceneCloser();
    }
    protected override void OnSceneStarter()
    {
        //base.OnSceneStarter();
        //ToDo: hier vl dann den Dialog starten lassen
    }

    private void OnSelectExited(SelectExitEventArgs arg0)
    {
        _isHolding = false;

        StopAllCoroutines();

        //if()

        StartCoroutine(OnReset());
    }

    IEnumerator OnReset()
    {
        yield return new WaitForSeconds(10f);

        if (!_isHolding)
        {
            Reset?.Invoke();
        }
    }

    protected override void OnStop()
    {
    }

    protected override void OnUpdate()
    {
    }

    public void OnHitCallback()
    {
        if (_finished) return;
        _finished = true;
        StopAllCoroutines();
        StartCoroutine(PassCallback());
    }

    IEnumerator PassCallback()
    {
        yield return new WaitForSeconds(time);

        EndScene();
    }
}
