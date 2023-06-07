using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class NetworkManagerRace : NetworkManager
{
    public Transform raceCarSpawn;
    public List<GameObject> raceCars;
    public Color[] colors;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //Transform start = raceCarSpawn;
        //GameObject avatar = Instantiate(playerPrefab, start.position, start.rotation);
        //avatar.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //NetworkServer.AddPlayerForConnection(conn, avatar);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }

}
