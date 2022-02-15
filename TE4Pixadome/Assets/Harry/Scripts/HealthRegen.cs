using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public bool regenOn;

    public float HealthRegeneration(float health, float healthRegen)
    {

        health += healthRegen * Time.deltaTime;
        return health;

    }
}
