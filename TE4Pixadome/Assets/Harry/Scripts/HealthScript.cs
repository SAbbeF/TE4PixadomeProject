using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //gör kod som tar skada på hp
    //gör kod som healar hp
    //ta in hp som en variabel från annat script
    public float TakeHealthDamage(float health, float damageTaken, GameObject gameObject)
    {
        health = health - damageTaken;

        DeathCheck(gameObject, health);

        return health;
    }

    public float Healing(float maxHealth, float currentHealth, float healingAmount)
    {
        currentHealth = currentHealth + healingAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        return currentHealth;
    }

    public void DeathCheck(GameObject gameObject, float health)
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
