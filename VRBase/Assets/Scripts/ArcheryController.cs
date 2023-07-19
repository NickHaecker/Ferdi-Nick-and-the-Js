using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryController : MiniGameController
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
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

    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(200f);

        EndScene();
    }

    protected override void OnUpdate()
    {
        
    }
}
