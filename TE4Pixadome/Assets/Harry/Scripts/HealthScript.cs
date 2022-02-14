using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //g�r kod som tar skada p� hp
    //g�r kod som healar hp
    //ta in hp som en variabel fr�n annat script
    public int TakeHealthDamage(int health, int damageTaken, GameObject gameObject)
    {
        health = health - damageTaken;

        DeathCheck(gameObject, health);

        return health;
    }

    public int Healing(int maxHealth, int currentHealth, int healingAmount)
    {
        currentHealth = currentHealth + healingAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        return currentHealth;
    }

    public void DeathCheck(GameObject gameObject, int health)
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
