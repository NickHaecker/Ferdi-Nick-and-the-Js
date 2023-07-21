using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MiniGameController
{
    private GameObject elevatorSpeaker;
    protected override void OnStart()
    {
        //throw new System.NotImplementedException();
        elevatorSpeaker = GameObject.Find("ElevatorControllerGameJam");
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Train/TrainIntro");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
        SecondLine();
    }

    protected override void OnStop()
    {
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Train/Ticket");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
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
    IEnumerator SecondLine()
    {
        yield return new WaitForSeconds(10f);
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Train/Shovel");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
    }
}
