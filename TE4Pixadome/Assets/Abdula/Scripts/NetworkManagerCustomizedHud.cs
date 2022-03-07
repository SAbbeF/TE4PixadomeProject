using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using TMPro;
using Mirage;

public class NetworkManagerCustomizedHud : NetworkBehaviour, ISaveable
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

    //[SerializeField]
    //private GameObject lobbyMenu;

    [SerializeField]
    private TMP_Text statusLabel;

    [Scene]
    [SerializeField]
    private string level01;

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
        //lobbyMenu.SetActive(false);
        offlineGO.SetActive(false);
        onlineGO.SetActive(true);
    }

    internal void OfflineSetActive()
    {
        mainMenu.SetActive(true);
        //lobbyMenu.SetActive(true);
        offlineGO.SetActive(true);
        onlineGO.SetActive(false);
    }

    public void StartHostButtonHandler()
    {
        SetLabel("Host Mode");
        networkManagerLobby.Server.StartServer(networkManagerLobby.Client);
        OnlineSetActive();
        //sceneManager.ServerLoadSceneAdditively("Assets/Scenes/Level01.unity", sceneManager.Server.Players);
        //sceneManager.ClientStartSceneMessage
        //sceneManager.ScenesPlayerIsIn
        //sceneManager.

        //sceneManager.ServerLoadSceneNormal("Level01");
        sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
        //SceneManager.LoadSceneAsync(level01);

    }

    public void StartServerOnlyButtonHandler()
    {
        SetLabel("Server Mode");
        networkManagerLobby.Server.StartServer();
        OnlineSetActive();
        //sceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
        //sceneManager.ServerLoadSceneAdditively("Assets/Scenes/Level01.unity", sceneManager.Server.Players);

    }

    public void StartClientButtonHandler()
    {
        SetLabel("Client Mode");
        networkManagerLobby.Client.Connect(networkAddress);
        //if (networkManagerLobby.Server.Active)
        //{
        //    Debug.Log("There is a server");
        //}
        OnlineSetActive();
        //sceneManager.ServerLoadSceneNormal("Assets/Abdula/Scenes/Lobby.unity");
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

    public void PopulateSaveData(PlayerData playerData)
    {

    }

    public void LoadFromSaveData(PlayerData playerData)
    {

    }
}