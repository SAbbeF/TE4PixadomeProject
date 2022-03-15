using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    Healtbar healthbar;
    ManaScript manaScript;

    public float damage;
    public float maxHealth;
    public float currentHealth;
    public float armor;
    public float magicDefense;
    public float maxMana;
    public float currentMana;
    public float manaRegenerationTickRate;
    public float attackRange;
    public float attackSpeed;
    public float cooldownReduction; 
    public float movementSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        if (gameObject.GetComponent<Healtbar>() != null)
        {

            healthbar = gameObject.GetComponent<Healtbar>();
            healthbar.SetMaxHealth(maxHealth);

        }

        if (gameObject.GetComponent<ManaScript>() != null)
        {

            manaScript = gameObject.GetComponent<ManaScript>();
            manaScript.SetMaxMana(maxMana);

        }

    }

}
