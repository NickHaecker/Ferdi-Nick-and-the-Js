using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MiniGameController : MonoBehaviour
{
    public Action StartScene;
    public Action CloseScene;

    [SerializeField]
    private Reward _reward = null;

    void Start()
    {
        Elevator.Instance.TakeMinigameController(this);

        StartScene += OnSceneStarter;
        CloseScene += OnSceneCloser;

        OnStart();
    }

    protected abstract void OnStart();
    protected abstract void OnStop();

    protected virtual void OnSceneStarter()
    {
        StartCoroutine(End());
    }
    protected virtual void OnSceneCloser()
    {

    }

    public void OnStartScene()
    {
        StartScene?.Invoke();
    }

    public void OnCloseScene()
    {
        CloseScene?.Invoke();
    }


    void Update()
    {
        OnUpdate();
    }

    public void PassReward()
    {
        Elevator.Instance.TakeReward(_reward);
    }

    protected abstract void OnUpdate();

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);

        EndScene();
    }

    protected void EndScene()
    {
        OnStop();

        Elevator.Instance.RemoveMinigameController(this);
    }
    public void RemoveListener()
    {
        PassReward();

        StartScene -= OnSceneStarter;
        CloseScene -= OnSceneCloser;
    }
}
