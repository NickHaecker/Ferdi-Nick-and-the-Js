using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MiniGameController
{
    protected override void OnStart()
    {
        GravityController.Instance.EnterOrbit();
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Space/SpaceIntro");
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
        StartCoroutine(SecondLine());
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
    IEnumerator SecondLine()
    {
        yield return new WaitForSeconds(20f);
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Space/BeepBoop");
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
    }
}
