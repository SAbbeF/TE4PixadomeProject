using Mirage;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedCharacterSpawner : CharacterSpawner
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
            Server.Disconnected.AddListener(OnServerAddPlayer);
            Server.Disconnected.AddListener(OnServerDisconnect);
            Server.Stopped.AddListener(OnStopServer);
        }
    }

    public override void OnServerAddPlayer(INetworkPlayer player)
    {
        //Needs code update
        //if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == startMenu)
        //{

        //}

        //bool isLeader = RoomPlayers.Count == 0;

        //NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);

        //roomPlayerInstance.Isleader = isLeader;

        //ServerObjectManager.AddCharacter(player, roomPlayerInstance.gameObject);

        //NotifyPlayersOfReadyState();

        base.OnServerAddPlayer(player);
        //NetworkIdentity character = Instantiate(PlayerPrefab);
        //ServerObjectManager.AddCharacter(player, character.gameObject);
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