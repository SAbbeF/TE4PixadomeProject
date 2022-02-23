using System.IO;
using UnityEngine;
using Mirage;

public class SaveJSONData : NetworkBehaviour
{
    private PlayerData playerData;

    private string projectPath;
    private string persistentPath;

    private SaveJSONData()
    {
        projectPath = "";
        persistentPath = "";
    }

    private void Start()
    {
        CreatePlayerData();
        SetPaths();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //SaveDataAtPersistentPath();
            SaveDataAtProjectPath();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //LoadDataFromPersistentPath();
            LoadDataFromProjectPath();
        }
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData(PlayerInputNameTextMashPro.DisplayName, 134f, "Player");
    }

    private void SetPaths()
    {
        projectPath = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveDataAtPersistentPath()
    {
        string savePath = persistentPath;

        Debug.Log("Save data at " + savePath);

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter streamWriter = new StreamWriter(savePath);
        streamWriter.Write(json);
    }

    public void SaveDataAtProjectPath()
    {
        string savePath = projectPath;

        Debug.Log("Save data at " + savePath);

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter streamWriter = new StreamWriter(savePath);
        streamWriter.Write(json);
    }

    public void LoadDataFromPersistentPath()
    {
        using StreamReader streamReader = new StreamReader(persistentPath);
        string json = streamReader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }

    public void LoadDataFromProjectPath()
    {
        using StreamReader streamReader = new StreamReader(projectPath);
        string json = streamReader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }
}
