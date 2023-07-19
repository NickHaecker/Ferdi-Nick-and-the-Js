using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryController : MiniGameController
{
    public float targetsShot = 0;
    private bool questOneDone = false;
    protected override void OnStart()
    {
        // narrator "you are in a medieval town, shoot some targets" & Villagers idle
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
        yield return new WaitForSeconds(200f);

        EndScene(); //unloads scene
    }

    protected override void OnUpdate()
    {
        if (targetsShot == 5 && !questOneDone)
        {
            TargetsShot();
        }
        if (targetsShot == 8 && questOneDone)
        {
            EnemiesShot();
        }
    }

    private void TargetsShot()
    {
        questOneDone = true;
        // narrator "you are a good archer, lets go" 
        // wait for couple seconds
        // narrator "someones attacking! & Spawn Enemies & scared villagers
    }
    private void EnemiesShot()
    {
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
