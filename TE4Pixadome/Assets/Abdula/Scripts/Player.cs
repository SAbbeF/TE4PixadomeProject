using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private TextMesh playerActiveName;


    private void Update()
    {
        playerActiveName.text = PlayerInputNameTextMashPro.DisplayName;

        if (!IsLocalClient)
        {
            return;
        }

        playerActiveName.color = Color.green;
    }
}
