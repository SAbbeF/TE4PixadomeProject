using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public GameObject weapon;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public float damageAmount;
    public int attacksBeforeSpecial;
    public int attackCounter;
    protected bool isUsingSpecial;

    Animator anim;

    protected Stats stats;
    protected HealthScript health;

    private void Start()
    {
        attackCounter = 0;
    }


    //ändra script så att den skiftar mellan normal och special attack
    public void WeaponAttack()
    {
        canAttack = false;
        anim = weapon.GetComponent<Animator>();

        if (attacksBeforeSpecial > 0)
        {

            if (attackCounter < attacksBeforeSpecial)
            {

                anim.SetTrigger("Attack");
                StartCoroutine(ResetAttackCooldown());

                attackCounter++;
            }
            else
            {

                anim.SetTrigger("SpecialAttack");
                StartCoroutine(ResetAttackCooldown());

                attackCounter = 0;
            }
        }
        else
        {

            anim.SetTrigger("Attack");
            StartCoroutine(ResetAttackCooldown());
        
        }
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
            if (collider.tag == "Ground" && anim.GetBool("SpecialAttack") == true)
            {
                isUsingSpecial = true;
            }

            if (collider.GetComponent<HealthScript>() != null)
            {
                stats = collider.GetComponent<Stats>();
                health = collider.GetComponent<HealthScript>();

                stats.currentHealth = health.TakeHealthDamage(stats.currentHealth, damageAmount * 3, collider.gameObject, weapon);
            }

        }
    }
}
