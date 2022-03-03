using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float damage;
    public float maxHealth;
    public float currentHealth;
    public float armor;
    public float magicDefense;
    public float maxMana;
    public float currentMana;
    public float attackRange;
    public float attackSpeed;
    public float cooldownReduction; 
    public float movementSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

}
