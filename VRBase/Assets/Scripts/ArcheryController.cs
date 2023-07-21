using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryController : MiniGameController
{
    public GameObject standees;
    public GameObject villagers;
    public float targetsShot = 0;
    public float standeesShot = 0;
    private bool questOneCompleted = false;
    private bool questTwoCompleted = false;
    GameObject elevatorSpeaker;
    protected override void OnStart()
    {
        // narrator "you are in a medieval town, shoot some targets" & Villagers idle
        elevatorSpeaker = GameObject.Find("ElevatorControllerGameJam");
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Archery/ArcheryIntro");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
    }

    protected override void OnStop() //of the existance of the scene
    {

    }

    protected override void OnSceneCloser()  //before the elevator closes
    {
        //base.OnSceneCloser();
    }

    protected override void OnSceneStarter() //after elevetor opened
    {
        //base.OnSceneStarter();
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        EndScene(); //unloads scene
    }

    protected override void OnUpdate()
    {
        if (targetsShot >= 4 && !questOneCompleted)
        {
            TargetsShot();
        }
        if (standeesShot >= standees.transform.childCount && questOneCompleted && !questTwoCompleted)
        {
            EnemiesShot();
        }
    }

    private void TargetsShot()
    {
        Debug.Log("TargetsShot");
        standees.SetActive(true);
        for (int i = 0; i < standees.transform.childCount; i++)
        {
            standees.transform.GetChild(i).gameObject.GetComponent<StandeeMovement>().StartMovement();
        }
        for (int i = 0; i < villagers.transform.childCount; i++)
        {
            villagers.transform.GetChild(i).gameObject.GetComponent<Animator>().SetTrigger("terrified");
        }
        questOneCompleted = true;
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Archery/ArcheryDefend");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
        // narrator "you are a good archer, lets go" 
        // wait for couple seconds
        // narrator "someones attacking! & Spawn Enemies & scared villagers
    }
    private void EnemiesShot()
    {
        for (int i = 0; i < villagers.transform.childCount; i++)
        {
            villagers.transform.GetChild(i).gameObject.GetComponent<Animator>().SetTrigger("cheer");
        }
        Debug.Log("EnemiesShot");
        questTwoCompleted = true;
        elevatorSpeaker.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Archery/ArcheryYay");
        elevatorSpeaker.GetComponent<AudioSource>().Play();
        GameObject.Find("Villagers").GetComponent<AudioSource>().Play();
        StartCoroutine(End());
        // narrator "you saved the city!" & happy villagers
        // wait for couple seconds
        // EndScene(); //unloads scene
    }

    /* Scene flow: 
    1. Elevator opens
    2. Narrator: "You are in a medieval town, shoot some targets" & Villagers Idle Animation
    3. IF: Player shoots 5 targets: Narrator: "You are a good archer, lets go"
    4. Narrator: "SOMEONE IS ATTACKING THE VILLAGE! DEFEND IT!" & Villagers Scared Animtion & Enemies enter scene
    5. IF: Player shoots 3 enemies: Narrator: "You saved the city!" & Villagers Happy Animation
    6. Elevator closes
    */
}
