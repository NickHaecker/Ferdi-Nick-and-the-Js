using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDespawn : MonoBehaviour
{
    public MeshRenderer Coal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Shovel>(out Shovel shovel))
        {
            shovel.GetMeshRenderer().enabled = false;
        }

    }
}
