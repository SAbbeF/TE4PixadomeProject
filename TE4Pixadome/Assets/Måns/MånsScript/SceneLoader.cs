using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirage;

public class SceneLoader : NetworkBehaviour
{
    CustomizedNetworkSceneManager sceneManager;

    public SceneLoader()
    {
        sceneManager = GetComponent<CustomizedNetworkSceneManager>();


    }

    public void LoadScene(string sceneName)
    {

        sceneManager.ServerLoadSceneNormal("Assets/Scenes/" + sceneName);
        
    }

}
