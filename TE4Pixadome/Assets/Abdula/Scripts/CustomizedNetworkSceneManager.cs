using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;
using UnityEngine.SceneManagement;

public class CustomizedNetworkSceneManager : NetworkSceneManager
{
    #region Changing scene additivly
    //[SerializeField]
    //private NetworkManagerLobby networkManagerLobby;

    //[Header("MultiScene Setup")]
    //[SerializeField]
    //private int instances;

    //[Scene]
    //[SerializeField]
    //private string gameScene;

    //List<Scene> subScenes = new List<Scene>();

    //CustomizedNetworkSceneManager()
    //{
    //    instances = 3;
    //}

    //private void Start()
    //{
    //    Server.Started.AddListener(() => StartCoroutine(LoadSubScenes()));
    //    Server.Authenticated.AddListener(OnServerAddPlayer);
    //    Server.Stopped.AddListener(OnStopServer);
    //    Client.Disconnected.AddListener(OnStopClient);
    //}

    //public void OnServerAddPlayer(INetworkPlayer player)
    //{
    //    // This delay is really for the host player that loads too fast for the server to have subscene loaded
    //    StartCoroutine(AddPlayerDelayed(player));
    //}

    //IEnumerator AddPlayerDelayed(INetworkPlayer player)
    //{
    //    yield return new WaitForSeconds(.5f);

    //    networkManagerLobby.ServerObjectManager.NetworkSceneManager.ServerLoadSceneAdditively(gameScene, Server.Players);

    //    if (subScenes.Count > 0)
    //    {
    //        SceneManager.MoveGameObjectToScene(player.Identity.gameObject, subScenes[subScenes.Count]);
    //    }
    //}

    //IEnumerator LoadSubScenes()
    //{
    //    for (int index = 0; index < instances; index++)
    //    {
    //        yield return SceneManager.LoadSceneAsync(gameScene, new LoadSceneParameters { loadSceneMode = LoadSceneMode.Additive, localPhysicsMode = LocalPhysicsMode.Physics3D });
    //        subScenes.Add(SceneManager.GetSceneAt(index + 1));
    //    }
    //}

    //public void OnStopServer()
    //{
    //    Server.SendToAll(new SceneMessage { MainActivateScene = gameScene, SceneOperation = SceneOperation.UnloadAdditive });
    //    StartCoroutine(UnloadSubScenes());
    //}

    //public void OnStopClient(ClientStoppedReason reason)
    //{
    //    if (!Server.Active)
    //    {
    //        StartCoroutine(UnloadClientSubScenes());
    //    }   
    //}

    //IEnumerator UnloadClientSubScenes()
    //{
    //    for (int index = 0; index < SceneManager.sceneCount; index++)
    //    {
    //        if (SceneManager.GetSceneAt(index) != SceneManager.GetActiveScene())
    //        {
    //            yield return SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(index));
    //        }
    //    }
    //}

    //IEnumerator UnloadSubScenes()
    //{
    //    for (int index = 0; index < subScenes.Count; index++)
    //    {
    //        yield return SceneManager.UnloadSceneAsync(subScenes[index]);
    //    }

    //    subScenes.Clear();

    //    yield return Resources.UnloadUnusedAssets();
    //}
    #endregion

    [SerializeField]
    NetworkManagerLobby networkManagerLobby;


}
