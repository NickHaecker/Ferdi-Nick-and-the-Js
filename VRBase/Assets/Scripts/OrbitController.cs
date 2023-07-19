using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MiniGameController
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {
        GravityController.Instance.ExitOrbit();
    }

    protected override void OnUpdate()
    {
        
    }
    protected override void OnSceneCloser()
    {
        //base.OnSceneCloser();
    }
    protected override void OnSceneStarter()
    {
        //base.OnSceneStarter();
        StartCoroutine(End());

        GravityController.Instance.EnterOrbit();
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(300f);

        EndScene();
    }
}
