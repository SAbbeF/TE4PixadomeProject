using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private TextMesh playerActiveName;

    private Camera playerCamera;


    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        playerActiveName.text = PlayerInputNameTextMashPro.PlayerDisplayedName;

        if (!IsLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
        }

        transform.LookAt(playerCamera.transform);

        if (!IsLocalClient)
        {
            return;
        }

        playerActiveName.color = Color.green;
    }
}
