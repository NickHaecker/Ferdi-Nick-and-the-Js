using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MiniGameController : MonoBehaviour
{
    public Action StartScene;
    public Action CloseScene;
    public Action AfterCloseScene;

    [SerializeField]
    private Reward _reward = null;
    [SerializeField]
    private Material _skybox = null;

    void Start()
    {
        Elevator.Instance.TakeMinigameController(this);

        SkyboxController.Instance.ChangeSkybox(_skybox);

        StartScene += OnSceneStarter;
        CloseScene += OnSceneCloser;
        AfterCloseScene += OnAfterCloseScene;


        OnStart();
    }

    protected abstract void OnStart();
    protected abstract void OnStop();

    protected virtual void OnAfterCloseScene() { }

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

        AfterCloseScene?.Invoke();
        AfterCloseScene -= OnAfterCloseScene;

        StartScene -= OnSceneStarter;
        CloseScene -= OnSceneCloser;
    }
}
