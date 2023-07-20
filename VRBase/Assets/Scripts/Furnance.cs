using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnance : MonoBehaviour
{
    public float CoalLeft = 0;
    public MeshRenderer Coal;

    // Update is called once per frame
    void Update()
    {

            if (CoalLeft > 0)
            {
                if(this.GetComponentInChildren<ParticleSystem>().isStopped) this.GetComponentInChildren<ParticleSystem>().Play();
                CoalLeft -= Time.deltaTime;
            }
            else
            {
                CoalLeft = 0;
                this.GetComponentInChildren<ParticleSystem>().Stop();
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Coal.enabled)
        {
            if (CoalLeft <= 40)
            {
                CoalLeft += 10;
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }

}
