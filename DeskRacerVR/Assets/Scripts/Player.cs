using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Wave.Essence.Interaction.Mode;
public class Player : NetworkBehaviour
{
    [SerializeField]
    private GameObject _cam;
    [SerializeField]
    private GameObject _leftController;
    [SerializeField]
    private GameObject _rightController;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            _cam.SetActive(true);
            _leftController.SetActive(true);
            _rightController.SetActive(true);
            GetComponent<InteractionModeManager>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            transform.position = _cam.transform.position;
            transform.rotation = _cam.transform.rotation;
        }
    }
}
