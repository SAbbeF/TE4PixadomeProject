using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputNameTextMashPro : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TMP_InputField nameInputField;

    //[SerializeField]
    //private Button continueButton;

    public static string DisplayName { get; private set; }

    private const string PlayerPrefabsNameKey = "PlayerName";

    PlayerInputNameTextMashPro()
    {
        nameInputField = null;
        //continueButton = null;
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

        nameInputField.text = defualtName;

        //SetPlayerName(defualtName);
    }

    public void SetPlayerName(string name)
    {
        //continueButton.interactable = !string.IsNullOrEmpty(name);
        //A way to check if the inputfield is full
    }

    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;

        PlayerPrefs.SetString(PlayerPrefabsNameKey, DisplayName);
    }
}
