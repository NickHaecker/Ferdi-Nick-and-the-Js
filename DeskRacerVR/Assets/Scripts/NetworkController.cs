using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkController : NetworkManager
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField] private GameObject _hierachie;
    [SerializeField]
    private ScenePerceptionController _perceptionController;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(_playerPrefab, _hierachie.transform);
        Player pScript = player.GetComponent<Player>();
        //_perceptionController.TakeNewConnector(pScript);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
