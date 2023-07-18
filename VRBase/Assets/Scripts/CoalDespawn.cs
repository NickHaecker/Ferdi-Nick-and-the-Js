using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalDespawn : MonoBehaviour
{
    public MeshRenderer Coal;

    private void OnTriggerEnter(Collider other)
    {     
            Coal.enabled = false;
     
    }
}
