using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public Throttle throttle;
    public Furnance furnance;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
        throttle = GetComponent<Throttle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (furnance.FurnanceOn)
        {
            if (throttle.throttle != 0)
            {
                GetComponent<Animator>().enabled = true;
                GetComponent<Animator>().speed = throttle.throttle;

            }
            else
            {
                GetComponent<Animator>().enabled = false;
            }
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
