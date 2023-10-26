using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;

    public Transform spawnOne;
    public Transform spawnTwo;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("add player method called");

        GameObject playerInstance;

        if(conn.connectionId == 0)
        {
            playerInstance = Instantiate(playerPrefab1, spawnOne.position, Quaternion.identity);
            Debug.Log(conn.connectionId);
        }
        else
        {
            playerInstance = Instantiate(playerPrefab2, spawnTwo.position, Quaternion.identity);
            Debug.Log(conn.connectionId);
        }

        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}
