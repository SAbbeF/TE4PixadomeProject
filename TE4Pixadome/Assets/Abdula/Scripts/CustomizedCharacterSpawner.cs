using Mirage;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedCharacterSpawner : CharacterSpawner
{
    [SerializeField]
    private int minimumPlayerCount;

    [Scene]
    //[SerializeField]
    private string startMenu;

    [Header("Room")]
    //[SerializeField]
    private NetworkRoomPlayerLobby roomPlayerPrefab;

    public List<NetworkRoomPlayerLobby> RoomPlayers { get; }

    [SerializeField]
    private List<Transform> spawnableLocations;

    private int spawnableLocationIndex;

    CustomizedCharacterSpawner()
    {
        minimumPlayerCount = 2;

        RoomPlayers = new List<NetworkRoomPlayerLobby>();
    }

    public override void Awake()
    {
        base.Awake();

        if (Server != null)
        {
           //Server.Authenticated.AddListener(SpawnPlayer); //Do not need because of override.
            Server.Disconnected.AddListener(OnServerDisconnect);
            Server.Stopped.AddListener(OnStopServer);
        }
    }

    public override void OnServerAddPlayer(INetworkPlayer player)
    {
        spawnableLocations.Clear();

        GameObject[] spawnPlatforms = GameObject.FindGameObjectsWithTag("SpawnLocation");

        foreach (GameObject spawnPlatform in spawnPlatforms)
        {
            Transform spawnLocation = spawnPlatform.GetComponent<Transform>();
            spawnableLocations.Add(spawnLocation);
        }

        //base.OnServerAddPlayer(player);
        //NetworkIdentity character = Instantiate(PlayerPrefab, new Vector3(450, 0, 480), Quaternion.Euler(Vector3.zero));
        Transform spawnPosition = GetSpawnLoaction();
        NetworkIdentity character = Instantiate(PlayerPrefab, spawnPosition.position, spawnPosition.rotation);
        
        ServerObjectManager.AddCharacter(player, character.gameObject);
        //DontDestroyOnLoad(character); 
    }

    public Transform GetSpawnLoaction()
    {
        Transform spawnLocation = spawnableLocations[spawnableLocationIndex];
        spawnableLocationIndex = (spawnableLocationIndex + 1) % spawnableLocations.Count;

        return spawnLocation;
    }

    public void SpawnPlayer(INetworkPlayer player)
    {
        //Needs code update
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().path == startMenu)
        {
            bool isLeader = RoomPlayers.Count == 0;

            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);

            roomPlayerInstance.Initialize(this);

            roomPlayerInstance.Isleader = isLeader;

            ServerObjectManager.AddCharacter(player, roomPlayerInstance.gameObject);

            NotifyPlayersOfReadyState();
        }
    }

    public void OnServerDisconnect(INetworkPlayer player)
    {
        if (player.Identity != null)
        {
            var roomPlayer = player.Identity.gameObject.GetComponent<NetworkRoomPlayerLobby>();
            //NetworkRoomPlayerLobby player = conn.Identity.gameObject.GetComponent<NetworkRoomPlayerLobby>();

            RoomPlayers.Remove(roomPlayer);

            NotifyPlayersOfReadyState();
        }
    }

    private void OnStopServer()
    {
        // Server stopped
        RoomPlayers.Clear();
    }

    public void NotifyPlayersOfReadyState()
    {
        foreach (var player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }

        //foreach (NetworkRoomPlayerLobby player in RoomPlayers)
        //{
        //    player.HandleReadyToStart(IsReadyToStart());
        //}
    }

    public bool IsReadyToStart()
    {
        if (Server.NumberOfPlayers < minimumPlayerCount)
        {
            return false;
        }

        foreach (var player in RoomPlayers)
        {
            if (!player.isReady)
            {
                return false;
            }
        }

        //foreach (NetworkRoomPlayerLobby player in RoomPlayers)
        //{
        //    if (!player.isReady)
        //    {
        //        return false;
        //    }
        //}

        return true;
    }
}