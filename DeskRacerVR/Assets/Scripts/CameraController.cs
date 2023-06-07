using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;
    [SerializeField]
    private GameObject _waveRig;
    [SerializeField]
    private GameObject _serverCam;
    // Start is called before the first frame update
    void Start()
    {
        if(_sceneController.BuildType.type == EBuildType.CLIENT)
        {
            //_waveRig.SetActive(true);
            _serverCam.SetActive(false);
        }
        else
        {
            //_waveRig.SetActive(false);
            _serverCam.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
