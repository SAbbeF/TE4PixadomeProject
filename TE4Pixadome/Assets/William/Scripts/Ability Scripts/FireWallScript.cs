using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallScript : BaseAbility
{

    public GameObject owner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthScript>() != null)
        {
            DealDamageOnCollision(other, owner);
        }

        //if (other.CompareTag("Projectile"))
        //{
        //    Destroy(other);
        //}

    }
}
