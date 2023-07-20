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
        GravityController.Instance.ExitOrbit();
    }

    protected override void OnUpdate()
    {

    }
    protected override void OnSceneCloser()
    {
        //base.OnSceneCloser();
        //GravityController.Instance.ExitOrbit();
    }
    protected override void OnSceneStarter()
    {
        //base.OnSceneStarter();

        StartCoroutine(End());


    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(40f);

        EndScene();
    }
}
