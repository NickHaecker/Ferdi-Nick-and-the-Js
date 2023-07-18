using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnance : MonoBehaviour
{
    public float CoalLeft = 0;
    public bool FurnanceOn = false;



    // Update is called once per frame
    void Update()
    {
        if (FurnanceOn)
        {
            if (CoalLeft > 0)
            {
                CoalLeft -= Time.deltaTime;
            
            }
            else
            {
                CoalLeft = 0;
                FurnanceOn = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CoalLeft += 10;
        FurnanceOn = true;
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }

}
