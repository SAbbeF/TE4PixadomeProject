using Mirage;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField]
    private GameObject lobbyUI;

    [SerializeField]
    private TMP_Text[] playerNameText;

    [SerializeField]
    private TMP_Text[] playerReadyText;

    [SerializeField]
    private Button startGameButton;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string displayName;

    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool isReady;

    private bool isLeader;

    public bool Isleader
    {
        set 
        {   isLeader = value;
            startGameButton.gameObject.SetActive(value);
        }
    }

    private NetworkManagerLobby lobby;


    //public NetworkManagerLobby Lobby
    //{
    //    get
    //    {
    //        if (networkManagerLobby != null)
    //        {
    //            return networkManagerLobby;
    //        }

    //        //return NetworkManager.singleton as NetworkManagerLobby;
    //    }
    //}

    NetworkRoomPlayerLobby()
    {
        lobbyUI = null;

        playerNameText = new TMP_Text[4];
        playerReadyText = new TMP_Text[4];

        startGameButton = null;

        displayName = "Loading...";

        isReady = false;
    }

    private void Awake()
    {
        Identity.OnAuthorityChanged.AddListener(OnStartAuthority);
        Identity.OnStartClient.AddListener(OnStartClient);
        Client.Disconnected.AddListener(OnClientDisconnected);
    }

    private void OnStartAuthority(bool hasAuthority)
    {
        //In case PlayerInputName script is being used
        CmdSetDisplayName(PlayerInputName.DisplayName);

        //In case PlayerInputNameTextMashPro is being used;
        CmdSetDisplayName(PlayerInputNameTextMashPro.DisplayName);

        lobbyUI.SetActive(true);
    }

    private void OnStartClient()
    {
        lobby.RoomPlayers.Add(this);

        UpdateDisplay();
    }

    private void OnClientDisconnected(ClientStoppedReason reason)
    {
        //Need to duoble check this method if it's the right one
        lobby.RoomPlayers.Remove(this);

        UpdateDisplay();
    }


    public void HandleDisplayNameChanged(string oldValue, string newValue)
    {
        UpdateDisplay();
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue)
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (!HasAuthority)
        {
            //foreach (var player in lobby.RoomPlayers)
            //{
            //    if (player.HasAuthority)
            //    {
            //        player.UpdateDisplay();
            //        break;
            //    }
            //}

            foreach (NetworkRoomPlayerLobby player in lobby.RoomPlayers)
            {
                if (player.HasAuthority)
                {
                    player.UpdateDisplay();
                    break;
                }
            }

            return;
        }

        for (int i = 0; i < playerNameText.Length; i++)
        {
            playerNameText[i].text = "Waiting For Player...";
            playerReadyText[i].text = string.Empty;
        }

        for (int i = 0;i < playerReadyText.Length; i++)
        {
            playerNameText[i].text = lobby.RoomPlayers[i].displayName;
            playerReadyText[i].text = lobby.RoomPlayers[i].isReady ? "<color=green> Ready </color>" : "<color=red> Not Ready </color>";
        }
    }

    public void HandleReadyToStart(bool readyToStart)
    {
        if (!isLeader)
        {
            return;
        }

        startGameButton.interactable = readyToStart;
    }

    [ServerRpc]
    public void CmdSetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

    [ServerRpc]
    public void CmdReadyUo()
    {
        isReady = !isReady;

        lobby.NotifyPlayersOfReadyState();
    }

    [ServerRpc]
    public void CmdStartGame()
    {
        //if (lobby.RoomPlayers[0].connectionToClient != connectionToClient)
        //{
        //    return;
        //}

        //Start Game
    }
}
