using Mirage;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NetworkManagerLobby : NetworkManager
{
    [SerializeField]
    private int minimumPlayerCount;

    [Scene]
    [SerializeField]
    private string menuScene;

    [SerializeField]
    private NetworkManager networkManager;

    [Header("Room")]
    [SerializeField]
    private NetworkRoomPlayerLobby roomPlayerPrefab;

    public List<NetworkRoomPlayerLobby> RoomPlayers { get; }

    private UnityAction disconnectAction;
    //public static event Action OnClientConnected;
    //public static event Action OnClientDisconnectedFromServer;

    NetworkManagerLobby()
    {
        minimumPlayerCount = 2;

        menuScene = string.Empty;
        roomPlayerPrefab = null;

        RoomPlayers = new List<NetworkRoomPlayerLobby>();
    }

    private void Awake()
    {
        //Identity.OnStartClient.AddListener(OnStartClient);
        //Add a custom method to register all prefabs, can be tracked down from ClientObjectManager, RegisterSpawnPrefabs()

        //Client.Authenticated.AddListener(OnClientConnect);
        //Server.Authenticated.AddListener(OnServerConnect);
        disconnectAction += OnClientDisconnected;
        //Client.Disconnected.AddListener(OnClientDisconnected);
    }

    private void OnClientDisconnected()
    {
        
    }

    //private void OnClientConnect(INetworkPlayer conn)
    //{
    //    //OnClientConnect?.Invoke(this, conn);
    //    OnClientConnected?.Invoke();
    //}

    //private void OnClientDisconnected(ClientStoppedReason arg0)
    //{
    //    throw new NotImplementedException();
    //    OnClientDisconnectedFromServer?.Invoke();
    //}

    //private void OnClientDisconnected()
    //{
    //    OnClientDisconnectedFromServer?.Invoke();
    //}

    //private void OnServerConnect(INetworkPlayer conn)
    //{

    //}

    public void NotifyPlayersOfReadyState()
    {
        foreach (var player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    public bool IsReadyToStart()
    {

        return true;
    }
}
