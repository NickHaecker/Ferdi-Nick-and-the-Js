using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ConnectionController : MonoBehaviour
{
    [SerializeField]
    private NetworkManager _networkManager;
    [SerializeField]
    private string _ip = "141.28.130.159";
    [SerializeField]
    //private SceneController _sceneController;
    // Start is called before the first frame update
    void Start()
    {
        _networkManager.networkAddress = _ip;
        if (SceneController.Instance.BuildType.type == EBuildType.SERVER)
        {
            _networkManager.StartServer();
        }
        else
        {
            _networkManager.StartClient();
        }
    }

    IEnumerator Connect()
    {
        yield return new WaitForSeconds(5);
        if (SceneController.Instance.BuildType.type == EBuildType.SERVER)
        {
            _networkManager.StartServer();
        }
        else
        {
            _networkManager.OnClientConnect();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
