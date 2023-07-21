using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalSpawn : MonoBehaviour
{
    public MeshRenderer Coal;
    public AudioSource[] audioSources;
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Coal.enabled = true;
        if (other.gameObject.TryGetComponent<Shovel>(out Shovel shovel))
        {
            audioSources[Mathf.RoundToInt(Random.Range(0, 2))].Play();
            shovel.GetMeshRenderer().enabled = true;
        }
    }
}
