using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BaseAbility : MonoBehaviour
{
    public float damageScale;
    public float speed;
    public float manaCost; //doesnt have to be mana could be other resources aswell :)
    public float lifeTime;
    protected float counter;

    protected AttackSystem attackSystem;
    protected GetTarget getTarget;
    protected SphereCollider mySphereCollider;
    protected Rigidbody myRigidbody;
    protected Camera playerCamera;
    protected Stats stats;
    protected HealthScript health;


    protected void Awake()
    {

        //getTarget = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<GetTarget>();
        attackSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackSystem>();

        mySphereCollider = GetComponent<SphereCollider>();
        mySphereCollider.isTrigger = true;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;


        if (lifeTime > 0)
        {
            Destroy(this.gameObject, lifeTime);
        }

    }

    protected void DealDamageOnCollision(Collider collider)
    {

        if (collider.GetComponent<HealthScript>() != null)
        {

            stats = collider.GetComponent<Stats>();
            health = collider.GetComponent<HealthScript>();

            stats.currentHealth = health.TakeHealthDamage(stats.currentHealth, /*stats.damage * */damageScale, collider.gameObject);

        }

    }

    private void Update()
    {
        //if (lifeTime > 0)
        //{

        //    counter += Time.fixedDeltaTime;

        //    if (counter >= lifeTime)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

    }


}
