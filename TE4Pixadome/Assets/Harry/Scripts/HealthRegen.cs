using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public bool regenOn;

    public int HealthRegeneration(int health)
    {

        health = health + 1;
        return health;

    }
}
