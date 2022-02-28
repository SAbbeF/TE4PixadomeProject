using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoManager : MonoBehaviour, ISaveable
{

    private float timer;
    private float saveTime;


    GameInfoManager()
    {
        saveTime = 5f;
    }

    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadJsonData(this);
    }

    private void Update()
    {
        ResetTimeDown();
    }

    private void ResetTimeDown()
    {
        timer += Time.deltaTime;
        if (timer >= saveTime)
        {
            SaveJsonData(this);
            timer = 0;
        }
    }

    private static void SaveJsonData(GameInfoManager gameInfoManager)
    {
        PlayerData myPlayerData = new PlayerData();

        gameInfoManager.PopulateSaveData(myPlayerData);

        if (FileManager.WriteToFile("SaveData01.dat", myPlayerData.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public void PopulateSaveData(PlayerData playerData)
    {
        playerData.playerName = PlayerInputNameTextMashPro.PlayerDisplayedName;
    }

    private static void LoadJsonData(GameInfoManager gameInfoManager)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            PlayerData myPlayerData = new PlayerData();
            myPlayerData.LoadFromJson(json);

            gameInfoManager.LoadFromSaveData(myPlayerData);
            Debug.Log("Load complete");
        }
    }

    public void LoadFromSaveData(PlayerData playerData)
    {
        PlayerInputNameTextMashPro.PlayerDisplayedName = playerData.playerName;
    }
}
