using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using TMPro;
using Mirage;

public class NetworkManagerCustomizedHud : NetworkBehaviour
{
    public NetworkManagerLobby networkManagerLobby;
    public NetworkSceneManager sceneManager;
    public string networkAddress;
    public bool dontDestroy;

    [Header("Prefab Canvas Elements")]

    [SerializeField]
    private TMP_InputField networkAddressInput;

    [SerializeField]
    private GameObject offlineGO;

    [SerializeField]
    private GameObject onlineGO;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private TMP_Text statusLabel;

    private NetworkManagerCustomizedHud()
    {
        networkAddress = "localhost";
        dontDestroy = true;
    }

    private void Start()
    {
        if (dontDestroy)
            DontDestroyOnLoad(transform.root.gameObject);

        Application.runInBackground = true;

        // return to offset menu when server or client is stopped
        networkManagerLobby.Server?.Stopped.AddListener(OfflineSetActive);
        networkManagerLobby.Client?.Disconnected.AddListener(_ => OfflineSetActive());
        //networkManagerLobby.Server.Connected.AddListener(OnServerSceneChange);
        //networkManagerLobby.Client.Connected.AddListener(OnClientSceneChange);
        
    }

    void SetLabel(string value)
    {
        //if (StatusLabel) StatusLabel.text = value;

        if (statusLabel)
        {
            statusLabel.text = value;
        }
    }

    internal void OnlineSetActive()
    {
        mainMenu.SetActive(false);
        offlineGO.SetActive(false);
        onlineGO.SetActive(true);
    }

    internal void OfflineSetActive()
    {
        mainMenu.SetActive(true);
        offlineGO.SetActive(true);
        onlineGO.SetActive(false);
    }

    public void StartHostButtonHandler()
    {
        SetLabel("Host Mode");
        networkManagerLobby.Server.StartServer(networkManagerLobby.Client);
        OnlineSetActive();

        //sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
    }

    public void StartServerOnlyButtonHandler()
    {
        SetLabel("Server Mode");
        networkManagerLobby.Server.StartServer();
        OnlineSetActive();
    }

    public void StartClientButtonHandler()
    {
        SetLabel("Client Mode");
        networkManagerLobby.Client.Connect(networkAddress);
        OnlineSetActive();
    }

    public void StopButtonHandler()
    {
        SetLabel(string.Empty);

        if (networkManagerLobby.Server.Active)
            networkManagerLobby.Server.Stop();
        if (networkManagerLobby.Client.Active)
            networkManagerLobby.Client.Disconnect();
        OfflineSetActive();
    }

    public void OnNetworkAddressInputUpdate()
    {
        //Standard
        //networkAddress = NetworkAddressInput.text;

        //TMP version
        networkAddress = networkAddressInput.text;
    }

    public void OnSceneChange()
    {
        sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
    }

    public void OnServerSceneChange(INetworkPlayer player)
    {
        player.SceneIsReady = false;
        player.Send(new SceneMessage { SceneOperation = 0 });

        //sceneManager.SetAllClientsNotReady();
        //sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
    }

    public void OnClientSceneChange(INetworkPlayer player)
    {
        sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
        ClientObjectManager.PrepareToSpawnSceneObjects();
    }

    public void OnSceneClienetChange()
    {
        networkManagerLobby.Client.Connect(networkAddress);
    }
}