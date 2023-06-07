using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private GameObject _cam;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            _cam.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
