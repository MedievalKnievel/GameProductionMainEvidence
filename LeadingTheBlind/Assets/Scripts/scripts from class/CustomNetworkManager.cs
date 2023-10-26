using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("add player method called");

        GameObject playerInstance;

        if(conn.connectionId == 0)
        {
            playerInstance = Instantiate(playerPrefab1, Vector3.zero, Quaternion.identity);
            Debug.Log(conn.connectionId);
        }
        else
        {
            playerInstance = Instantiate(playerPrefab1, Vector3.zero, Quaternion.identity);
        }

        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}
