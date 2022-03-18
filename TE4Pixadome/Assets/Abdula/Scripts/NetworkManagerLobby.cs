using Mirage;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerLobby : NetworkManager
{
    [Scene]
    [SerializeField]
    private string startMenu;

    //Manually connecting & disconnecting from server on client side.
    //Can make another script and call this events.
    public static event Action OnClientConnected;
    public static event Action OnClientDisconnect;

    private Dictionary<ulong, PlayerData> clientData;

    NetworkManagerLobby()
    {
        startMenu = string.Empty;
    }


    private void Awake()
    {
        Server.Started.AddListener(OnStartServer);
        Client.Started.AddListener(OnClientStarted);

        Client.Authenticated.AddListener(OnClientConnect);
        Client.Disconnected.AddListener(OnClientDisconnected);

        Server.Authenticated.AddListener(OnServerConnect);

        //Can be used to not pass any parameter
        //Client.Disconnected.AddListener(_ => OnClientDisconnected()); 

        //Add a custom method to register all prefabs, can be tracked down from ClientObjectManager, RegisterSpawnPrefabs()
        //Identity.OnStartClient.AddListener(OnStartClient);
    }

    private void Start()
    {

    }

    private void OnStartServer()
    {
        ClientObjectManager.spawnPrefabs = Resources.LoadAll<NetworkIdentity>("SpawnablePrefabs").ToList();

        clientData = new Dictionary<ulong, PlayerData>();

        
    }

    private void OnClientStarted()
    {
        var spawnablePrefabs = Resources.LoadAll<NetworkIdentity>("SpawnablePrefabs");

        foreach (var prefab in spawnablePrefabs)
        {
            ClientObjectManager.RegisterPrefab(prefab);
        }
    }

    private void OnClientConnect(INetworkPlayer conn)
    {
        // Client connected

        OnClientConnected?.Invoke();
    }

    private void OnClientDisconnected(ClientStoppedReason stoppedReason)
    {
        // Client disconnected

        OnClientDisconnect?.Invoke();
    }

    private void OnServerConnect(INetworkPlayer conn)
    {
        //Client connected(and authenticated) on server
        
        if (Server.NumberOfPlayers > Server.MaxConnections)
        {
            //Add logic later
            Server.RemoveConnection(conn);
            return;
        }

        //if (SceneManager.GetActiveScene().name == startMenu)
        //{
        //    Debug.Log("Correct name");
        //}

        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().path != startMenu)
        {
            Server.RemoveConnection(conn);
            return;
        }
    }
}
