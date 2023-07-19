using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int ring;

    public Color particleColor;
    public ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = transform.parent.gameObject.transform.parent.gameObject.GetComponent<ParticleSystem>();
    }
    public void Hit()
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
        Destroy(transform.parent.gameObject);
    }
}
