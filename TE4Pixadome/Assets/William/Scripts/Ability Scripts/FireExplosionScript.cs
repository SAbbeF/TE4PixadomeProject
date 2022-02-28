using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionScript : BaseAbility
{

    float durationUntilExplosion = 10;
    float timer = 0;
    Vector3 explosionSize = new Vector3(20, 20, 20);

    private void Update()
    {
        timer += Time.fixedDeltaTime;

        if (timer < durationUntilExplosion)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            damageScale = 5;
        }

        if (timer >= durationUntilExplosion)
        {
            transform.localScale = explosionSize;
            damageScale = 30;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthScript>() != null)
        {
            DealDamageOnCollision(other);
        }
    }


}
