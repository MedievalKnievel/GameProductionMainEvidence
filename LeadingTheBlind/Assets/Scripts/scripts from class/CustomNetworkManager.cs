using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerInstance;

    public Transform spawnOne;
    public Transform spawnTwo;

    public bool secondPlayerJoined = false;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("add player method called");

        //GameObject playerInstance;

        if(conn.connectionId == 0)
        {
            playerInstance = Instantiate(playerPrefab1, spawnOne.position, Quaternion.identity);
            Debug.Log(conn.connectionId);
            print("Player one joined");
        }
        else
        {
            playerInstance = Instantiate(playerPrefab2, spawnTwo.position, spawnTwo.rotation);
            Debug.Log(conn.connectionId);
            print("Player two joined");
            secondPlayerJoined = true;
        }

        NetworkServer.AddPlayerForConnection(conn, playerInstance);
    }
}
