using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalSpawn : MonoBehaviour
{
    public MeshRenderer Coal;

    private void OnTriggerEnter(Collider other)
    {
        Coal.enabled = true;
    }
}
