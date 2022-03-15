using TMPro;
using UnityEngine;
using Mirage;

public class PlayerDisplayName : NetworkBehaviour
{
    //[SerializeField]
    //private TextMesh playerName;

    [SerializeField]
    private TMP_Text playerActiveName;

    private Camera playerCamera;

    private void Start()
    {
        if (IsLocalPlayer)
        {
            playerActiveName.text = PlayerInputNameTextMashPro.PlayerDisplayedName;
        }
        //playerName.text = PlayerInputNameTextMashPro.PlayerDisplayedName;


        playerCamera = GetComponentInChildren<Camera>();

        if (!IsLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
        }

        if (!IsLocalPlayer) return;
        
        playerActiveName.color = Color.green;
        //playerName.color = Color.green;
    }

    private void LateUpdate()
    {
        //playerName.transform.LookAt(playerActiveName.transform.position + playerCamera.transform.forward);
        playerActiveName.transform.LookAt(playerCamera.transform);
        playerActiveName.transform.Rotate(Vector3.up * 180);
    }
}
