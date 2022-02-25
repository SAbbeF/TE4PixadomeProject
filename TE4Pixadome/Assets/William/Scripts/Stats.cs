using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public int armor;
    public int magicDefense;
    public int maxMana;
    public int currentMana;
    public int attackRange;
    public int speed;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

}
