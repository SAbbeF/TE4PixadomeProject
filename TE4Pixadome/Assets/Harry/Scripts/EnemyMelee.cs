using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public GameObject weapon;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public float damageAmount;

    protected Stats stats;
    protected HealthScript health;
    // Update is called once per frame
    public void WeaponAttack()
    {
        canAttack = false;
        Animator animation = weapon.GetComponent<Animator>();
        animation.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Enemy")
        {

            if (collider.GetComponent<HealthScript>() != null)
            {
                stats = collider.GetComponent<Stats>();
                health = collider.GetComponent<HealthScript>();

                stats.currentHealth = health.TakeHealthDamage(stats.currentHealth, damageAmount, collider.gameObject);
            }

        }
    }
}
