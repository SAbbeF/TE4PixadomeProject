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
        playerActiveName.text = PlayerInputNameTextMashPro.PlayerDisplayedName;

        //playerCamera = GetComponentInChildren<Camera>();

        //if (!IsLocalPlayer)
        //{
        //    playerCamera.gameObject.SetActive(false);
        //}

        if (!IsLocalClient)
        {
            return;
        }

        playerActiveName.color = Color.green;
    }

    private void Update()
    {
        //transform.LookAt(playerCamera.transform);
    }
}
