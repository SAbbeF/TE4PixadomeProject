using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryTestPlayer : MonoBehaviour
{

    public float health;
    public float damage;
    public float mana;
    public Healtbar healtbar;
    public HealthScript healthScript;
    public HealthRegen healthRegen;
    public Manabar manabar;
    public bool check;
    public bool manacheck;
    public GameObject deth;

    void Start()
    {

        healtbar.SetMaxHealth(health);
        manabar.SetMaxMana(mana);
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            health = healthScript.TakeHealthDamage(health, damage, deth, deth);
            healtbar.SetHealthValue(health);

        }
        if (healthRegen.regenOn)
        {
            health = healthRegen.HealthRegeneration(health, 1);
            healtbar.SetHealthValue(health);

        }
        if (manacheck)
        {
            mana = manabar.UseMana(mana, 3);
            manabar.SetManaValue(mana);
        }
    }
}
