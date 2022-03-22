using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutoAttack : BaseAbility
{

    public GameObject owner;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<HealthScript>() != null)
        {
            DealDamageOnCollision(other, owner);
            DestroySelf(other);
        }
    }

}
