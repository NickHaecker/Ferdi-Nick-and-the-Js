using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MiniGameController
{
    protected override void OnStart()
    {
        GravityController.Instance.EnterOrbit();
    }

    protected override void OnStop()
    {
        
    }

    protected override void OnUpdate()
    {

    }
    protected override void OnSceneCloser()
    {

    }
    protected override void OnSceneStarter()
    {
        StartCoroutine(End());
    }

    protected override void OnAfterCloseScene()
    {
        GravityController.Instance.ExitOrbit();
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(20f);

        EndScene();
    }
}
