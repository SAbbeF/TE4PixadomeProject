using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionScript : BaseAbility
{

    public GameObject owner;

    float durationUntilExplosion = 10;
    float explosionTimer = 0;
    Vector3 explosionSize = new Vector3(20, 20, 20);

    private void Update()
    {

        explosionTimer += Time.fixedDeltaTime;

        if (explosionTimer < durationUntilExplosion)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            damageScale = 5;
        }

        if (explosionTimer >= durationUntilExplosion)
        {
            transform.localScale = explosionSize;
            damageScale = 30;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthScript>() != null)
        {
            DealDamageOnCollision(other, owner);
        }
    }


}
