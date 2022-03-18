using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ability : MonoBehaviour
{

    public AttackScriptableObject abilityToCast;
    Stats stats;
    HealthScript health;
    Healtbar healthbar;
    SphereCollider mySphereCollider;
    Rigidbody myRigidbody;

    float explosionTimer;

    Vector3 explosionSize;

    private void Awake()
    {

        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.isTrigger = true;
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        explosionTimer = 0;
        explosionSize = new Vector3(abilityToCast.xRadius, abilityToCast.yRadius, abilityToCast.zRadius);

        if (abilityToCast.lifeTime > 0)
        {
            Destroy(this.gameObject, abilityToCast.lifeTime);
        }
    }

    private void Update()
    {
        //SKILLSHOT
        if (abilityToCast.isSkillshot)
        {
            MoveForward();
        }

        //EXPLOSION
        if (abilityToCast.isExplosion)
        {
            explosionTimer += Time.fixedDeltaTime;

            if (explosionTimer < abilityToCast.durationUntilExplosion)
            {
                transform.Translate(Vector3.forward * abilityToCast.speed * Time.fixedDeltaTime);
                abilityToCast.damageScale = 5;
            }

            if (explosionTimer >= abilityToCast.durationUntilExplosion)
            {
                transform.localScale = explosionSize;
                abilityToCast.damageScale = 30;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (abilityToCast.dealDamage)
        {
            DealDamageOnCollision(other);
        }

        if (abilityToCast.healTarget)
        {
            HealOnCollision(other);
        }

        if (abilityToCast.explodeOnCollision)
        {
            transform.localScale = explosionSize;
        }

        if (abilityToCast.destroyOnCollision && other.GetComponent<HealthScript>() != null)
        {
            Destroy(gameObject);
        }

    }

    void MoveForward()
    {

        transform.Translate(Vector3.forward * abilityToCast.speed * Time.fixedDeltaTime);

    }

    protected void DealDamageOnCollision(Collider collider)
    {

        if (collider.GetComponent<HealthScript>() != null)
        {

            stats = collider.GetComponent<Stats>();
            health = collider.GetComponent<HealthScript>();

            stats.currentHealth = health.TakeHealthDamage(stats.currentHealth, /*stats.damage * */abilityToCast.damageScale, collider.gameObject);

            if (collider.GetComponent<Healtbar>() != null)
            {
                healthbar = collider.GetComponent<Healtbar>();
                healthbar.SetHealthValue(stats.currentHealth);
            }

        }

    }

    void HealOnCollision(Collider collider)
    {

        stats = collider.GetComponent<Stats>();
        health = collider.GetComponent<HealthScript>();

        stats.currentHealth = health.Healing(stats.maxHealth, stats.currentHealth, /*stats.damage * */abilityToCast.damageScale);


        if (collider.GetComponent<Healtbar>() != null)
        {
            healthbar = collider.GetComponent<Healtbar>();
            healthbar.SetHealthValue(stats.currentHealth);
        }

    }

    

}
