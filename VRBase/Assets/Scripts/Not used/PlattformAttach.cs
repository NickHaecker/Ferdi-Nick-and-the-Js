using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformAttach : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Attach();
    }
    
    private void Attach()
    {
        Player.transform.parent = transform;
    }

}
