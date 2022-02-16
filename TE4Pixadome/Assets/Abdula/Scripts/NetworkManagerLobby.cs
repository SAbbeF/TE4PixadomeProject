using Mirage;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerLobby : NetworkManager
{
    [SerializeField]
    private int minimumPlayerCount;

    [Scene]
    [SerializeField]
    private string startMenu;

    [Header("Room")]
    [SerializeField]
    private NetworkRoomPlayerLobby roomPlayerPrefab;

    public List<NetworkRoomPlayerLobby> RoomPlayers { get; }

    //Manually connecting & disconnecting from server on client side.
    //Can make another script and call this events.
    public static event Action OnClientConnected;
    public static event Action OnClientDisconnect;

    NetworkManagerLobby()
    {
        minimumPlayerCount = 2;

        startMenu = string.Empty;
        roomPlayerPrefab = null;

        RoomPlayers = new List<NetworkRoomPlayerLobby>();
    }

    private void Awake()
    {
        //Identity.OnStartClient.AddListener(OnStartClient);
        //Add a custom method to register all prefabs, can be tracked down from ClientObjectManager, RegisterSpawnPrefabs()

        Server.Started.AddListener(OnStartServer);
        Server.Stopped.AddListener(OnStopServer);
        Server.Authenticated.AddListener(OnServerConnect);
        Server.Disconnected.AddListener(OnServerDisconnected);
        Server.Disconnected.AddListener(OnServerAddPlayer);
        Client.Authenticated.AddListener(OnClientConnect);
        Client.Disconnected.AddListener(OnClientDisconnected);
    }

    private void OnClientConnect(INetworkPlayer conn)
    {
        // Client connected
        OnClientConnected?.Invoke();
    }

    private void OnClientDisconnected(ClientStoppedReason Reason)
    {
        // Client disconnected

        OnClientDisconnect?.Invoke();
    }

    private void OnStartServer()
    {
        // Server started
        if (Server.NumberOfPlayers > Server.MaxConnections)
        {
            //Add logic later
        }
    }

    private void OnStopServer()
    {
        // Server stopped
        RoomPlayers.Clear();
    }

    private void OnServerConnect(INetworkPlayer conn)
    {
        // Client connected (and authenticated) on server
    }

    private void OnServerDisconnected(INetworkPlayer conn)
    {
        if (conn.Identity != null)
        {
            //var player = conn.Identity.gameObject.GetComponent<NetworkRoomPlayerLobby>();
            NetworkRoomPlayerLobby player = conn.Identity.gameObject.GetComponent<NetworkRoomPlayerLobby>();

            RoomPlayers.Remove(player);

            NotifyPlayersOfReadyState();
        }
    }

    public void OnServerAddPlayer(INetworkPlayer player)
    {
        if (SceneManager.GetActiveScene().name != startMenu)
        {
            bool isLeader = RoomPlayers.Count == 0;

            NetworkRoomPlayerLobby roomPlayerLobby = Instantiate(roomPlayerPrefab);

            roomPlayerLobby.Isleader = isLeader;

            ServerObjectManager.AddCharacter(player, roomPlayerPrefab.gameObject);

            NotifyPlayersOfReadyState();
        }
    }

    public void NotifyPlayersOfReadyState()
    {
        //foreach (var player in RoomPlayers)
        //{
        //    player.HandleReadyToStart(IsReadyToStart());
        //}

        foreach (NetworkRoomPlayerLobby player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    public bool IsReadyToStart()
    {
        if (Server.NumberOfPlayers < minimumPlayerCount)
        {
            return false;
        }

        //foreach (var player in RoomPlayers)
        //{
        //    if (!player.isReady)
        //    {
        //        return false;
        //    }
        //}

        foreach (NetworkRoomPlayerLobby player in RoomPlayers)
        {
            if (!player.isReady)
            {
                return false;
            }
        }

        return true;
    }
}
