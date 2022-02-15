using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryTestPlayer : MonoBehaviour
{

    public float health;
    public float damage;
    public Healtbar healtbar;
    public HealthScript healthScript;
    public HealthRegen healthRegen;
    public bool check;
    public GameObject deth;

    void Start()
    {

        healtbar.SetMaxHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            health = healthScript.TakeHealthDamage(health, damage, deth);
            healtbar.SetHealthValue(health);

        }
        if (healthRegen.regenOn)
        {
            health = healthRegen.HealthRegeneration(health, 1);
            healtbar.SetHealthValue(health);
        }
    }
}
