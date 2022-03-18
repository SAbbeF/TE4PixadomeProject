using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private NetworkManagerLobby networkManager;

    private void Start()
    {
        networkManager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManagerLobby>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            networkManager.NetworkSceneManager.ServerLoadSceneNormal("Assets/Scenes/Level01.unity");
        }
    }

}
