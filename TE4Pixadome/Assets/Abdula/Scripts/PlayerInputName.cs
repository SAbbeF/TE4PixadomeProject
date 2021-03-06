using UnityEngine;
using UnityEngine.UI;

public class PlayerInputName : MonoBehaviour
{
    [SerializeField]
    private Text playerNameInput;

    [SerializeField]
    private Text playerSavedName;

    public static string DisplayName { get; private set; }

    private const string PlayerPrefabsNameKey = "PlayerName";

    PlayerInputName()
    {
        playerNameInput = null;
    }

    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefabsNameKey))
        {
            return;
        }

        string defualtName = PlayerPrefs.GetString(PlayerPrefabsNameKey);

        playerSavedName.text = defualtName;
    }


    public void SavePlayerName()
    {
        DisplayName = playerNameInput.text;

        PlayerPrefs.SetString(PlayerPrefabsNameKey, DisplayName);
    }
}
