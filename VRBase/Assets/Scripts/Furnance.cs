using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnance : MonoBehaviour
{
    public float CoalLeft = 0;
    public MeshRenderer Coal;
    public AudioSource[] audioSources;
    public AudioSource trainNoises;

    // Update is called once per frame

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }
    void Update()
    {

        if (CoalLeft > 0)
        {
            if (!trainNoises.isPlaying) trainNoises.Play();
            if (this.GetComponentInChildren<ParticleSystem>().isStopped) this.GetComponentInChildren<ParticleSystem>().Play();
            CoalLeft -= Time.deltaTime;
        }
        else
        {
            trainNoises.Stop();
            CoalLeft = 0;
            this.GetComponentInChildren<ParticleSystem>().Stop();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Shovel>(out Shovel shovel))
        {
            Coal = shovel.GetMeshRenderer();
        }
        if (Coal.enabled)
        {
            if (CoalLeft <= 40)
            {
                audioSources[Mathf.RoundToInt(Random.Range(0, 1))].Play();
                audioSources[Mathf.RoundToInt(Random.Range(2, 4))].Play();
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
