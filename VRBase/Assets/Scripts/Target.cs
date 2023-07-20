using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int ring;
    public bool isStandee = false;
    private bool firstHit = true;
    public Color particleColor;
    public ParticleSystem particleSystem;
    public ArcheryController archeryController;
    void Start()
    {
        if (!isStandee) particleSystem = transform.parent.gameObject.transform.parent.gameObject.GetComponent<ParticleSystem>();
        archeryController = GameObject.Find("ArcheryController").GetComponent<ArcheryController>();

    }
    public void Hit()
    {

        if (!isStandee)
        {
            switch (ring)
            {
                case 1:
                    particleColor = Color.yellow;
                    break;
                case 2:
                    particleColor = Color.red;
                    break;
                case 3:
                    particleColor = Color.blue;
                    break;
                case 4:
                    particleColor = Color.black;
                    break;
                case 5:
                    particleColor = Color.white;
                    break;
            }
            particleSystem.startColor = particleColor;
            particleSystem.Play();
            Debug.Log(ring + "Hit");
            archeryController.targetsShot++;
            Destroy(transform.parent.gameObject);
        }
        if (isStandee)
        {
            if (firstHit)
            {
                archeryController.standeesShot++;
                firstHit = false;
                this.GetComponent<StandeeMovement>().StopAllCoroutines();
            }
        }
    }


}
