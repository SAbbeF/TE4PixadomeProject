using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemShockaWave : EnemyMelee
{
    public AiFollow aiFollow;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Enemy")
        {
            if (isUsingSpecial)
            {
                if (collider.GetComponent<HealthScript>() != null)
                {
                    stats = collider.GetComponent<Stats>();
                    health = collider.GetComponent<HealthScript>();

                    stats.currentHealth = health.TakeHealthDamage(stats.currentHealth, damageAmount, collider.gameObject);
                }

                isUsingSpecial = false;
            }
        }
    }
}
