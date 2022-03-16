using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //g�r kod som tar skada p� hp
    //g�r kod som healar hp
    //ta in hp som en variabel fr�n annat script

    //beh�ver l�gga till �gare av skadan
    //d� m�ste skotten ocks� ha �gare s� att skotten f�r en �gare och sedan fr�gar healthscriptet efter skottets �gare.
    //sedan m�ste man kalla p� att objektet letar efter xpscriptet och s� chekar man tagen efter spelare
    public float TakeHealthDamage(float health, float damageTaken, GameObject healthOwner)
    {
        health = health - damageTaken;

        DeathCheck(healthOwner, health);

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

    public void DeathCheck(GameObject healthOwner, float health)
    {

        if (health <= 0)
        {
            Destroy(healthOwner);
        }

    }
}
