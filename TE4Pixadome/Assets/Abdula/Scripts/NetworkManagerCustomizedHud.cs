using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirage;

public class NetworkManagerCustomizedHud : NetworkBehaviour
{
    public NetworkManagerLobby networkManagerLobby;
    public string networkAddress;
    public bool dontDestroy;

    [Header("Prefab Canvas Elements")]

    //Original lines from NetowrkManagerHud
    //public InputField NetworkAddressInput;
    //public GameObject OfflineGO;
    //public GameObject OnlineGO;
    //public Text StatusLabel;

    [SerializeField]
    private TMP_InputField networkAddressInput;

    [SerializeField]
    private GameObject offlineGO;

    [SerializeField]
    private GameObject onlineGO;

    [SerializeField]
    private GameObject nameSelectPanel;

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
        nameSelectPanel.SetActive(false);
        offlineGO.SetActive(false);
        onlineGO.SetActive(true);
    }

    internal void OfflineSetActive()
    {
        nameSelectPanel.SetActive(true);
        offlineGO.SetActive(true);
        onlineGO.SetActive(false);
    }

    public void StartHostButtonHandler()
    {
        SetLabel("Host Mode");
        networkManagerLobby.Server.StartServer(networkManagerLobby.Client);
        OnlineSetActive();
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
}
