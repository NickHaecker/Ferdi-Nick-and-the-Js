using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Action StartScene;
    public Action CloseScene;

    void Start()
    {
        Debug.Log("dddd");
        Elevator.Instance.TakeMinigameController(this);

        StartScene += OnSceneStarter;
    }

    private void OnSceneStarter()
    {
        StartCoroutine(End());
    }

    public void OnStartScene()
    {
        StartScene?.Invoke();
    }

    public void OnCloseScene()
    {
        CloseScene?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);

        EndScene();
    }

    private void EndScene()
    {
        Elevator.Instance.RemoveMinigameController(this);
    }
}
