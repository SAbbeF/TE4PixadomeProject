using Mirage;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerLobby : NetworkManager
{
    [Scene]
    [SerializeField]
    private string menuScene;

    [Header("Room")]
    [SerializeField]
    private NetworkRoomPlayerLobby roomPlayerPrefab;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnectedFromServer;

    NetworkManagerLobby()
    {
        menuScene = string.Empty;
        roomPlayerPrefab = null;
    }

    private void Awake()
    {
        //Identity.OnStartClient.AddListener(OnStartClient);
        //Add a custom method to register all prefabs, can be tracked down from ClientObjectManager, RegisterSpawnPrefabs()

        Client.Authenticated.AddListener(OnClientConnect);
        Server.Authenticated.AddListener(OnServerConnect);
        //Client.Disconnected.AddListener(OnClientDisconnected);
    }

    private void OnClientConnect(INetworkPlayer conn)
    {
        //OnClientConnect?.Invoke(this, conn);
        OnClientConnected?.Invoke();
    }

    //private void OnClientDisconnected(ClientStoppedReason arg0)
    //{
    //    throw new NotImplementedException();
    //    OnClientDisconnectedFromServer?.Invoke();
    //}

    //private void OnClientDisconnected()
    //{
    //    OnClientDisconnectedFromServer?.Invoke();
    //}

    private void OnServerConnect(INetworkPlayer conn)
    {

    }
}
