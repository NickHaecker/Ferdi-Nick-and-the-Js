using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceChecker : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        DeviceType deviceType = SystemInfo.deviceType;

        Debug.Log(deviceType);

        // Debug.Log()

        if(deviceType == DeviceType.Handheld){
            _gameController.InitSpectator();
        }else{
            _gameController.InitPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
