using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MiniGameController
{
    protected override void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnStop()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
    protected override void OnAfterCloseScene()
    {
        //base.OnAfterCloseScene();
    }
    protected override void OnSceneCloser()
    {
        //base.OnSceneCloser();
    }
    protected override void OnSceneStarter()
    {
        //base.OnSceneStarter();
    }

    public void ValidateEnd()
    {
        StartCoroutine(End()); 
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        EndScene();
    }
}
