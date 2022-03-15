using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class FixRotation : NetworkBehaviour
{
    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        if (!IsLocalPlayer) return;
        transform.rotation = rotation;
    }
}