using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int xpGetWhenKilled;
    Leveling leveling;
    //gör kod som tar skada på hp
    //gör kod som healar hp
    //ta in hp som en variabel från annat script

    //behöver lägga till ägare av skadan
    //då måste skotten också ha ägare så att skotten får en ägare och sedan frågar healthscriptet efter skottets ägare.
    //sedan måste man kalla på att objektet letar efter xpscriptet och så chekar man tagen efter spelare
    public float TakeHealthDamage(float health, float damageTaken, GameObject healthOwner, GameObject damageOwner)
    {
        health = health - damageTaken;

        DeathCheck(healthOwner, health, damageOwner);

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

    public void DeathCheck(GameObject healthOwner, float health, GameObject damageOwner)
    {

        if (health <= 0)
        {

            if (damageOwner.GetComponent<Leveling>() != null) 
            {
                leveling = damageOwner.GetComponent<Leveling>();
                leveling.currentXp = leveling.currentXp + xpGetWhenKilled;
            }

            Destroy(healthOwner);
        }

    }
}
